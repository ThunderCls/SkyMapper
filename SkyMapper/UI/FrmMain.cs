using System.Diagnostics;
using Microsoft.Extensions.Logging;
using SkyMapper.DataAccess.Dtos;
using SkyMapper.DataAccess.Models;
using SkyMapper.Extensions;
using SkyMapper.Services;
using SkyMapper.Utils;

namespace SkyMapper.UI;

public partial class FrmMain : Form
{
    private readonly ILogger<FrmMain> _logger;
    private readonly WorkerService _workerService;
    private readonly DataService _dataService;

    private CancellationTokenSource CancellationTokenSrc { get; set; } = new();
    private DateTime? StartProcessingTime { get; set; }
    private int _totalFiles;
    private int _processedFiles;
    private bool _isProcessing;
    private const string Mo2ProcessName = "ModOrganizer";
    private const string OutputLocation = "SkyMapper_Output";
    private const int MaxHashThreads = 10;

    private enum Status
    {
        None,
        Processing,
        Finished
    }

    public FrmMain(
        ILogger<FrmMain> logger,
        WorkerService workerService, 
        DataService dataService)
    {
        _logger = logger;
        _workerService = workerService;
        _dataService = dataService;
        
        _workerService.WorkerProgress += OnWorkerServiceProgress;
        _workerService.WorkerTerminate += OnWorkerServiceTerminate;
        _workerService.WorkerInit += OnWorkerServiceInit;
        _workerService.WorkerError += OnWorkerServiceError;

        InitializeComponent();
    }

    #region Events

    private async Task OnWorkerServiceInit(string file, CancellationToken cancellationToken)
    {
        var storedTexture = await _dataService.GetTextureFileAsync(file, cancellationToken);
        storedTexture.IsProcessed = false;
        storedTexture.FileHashMd5 = string.Empty;
        await _dataService.UpdateTextureFileAsync(storedTexture, cancellationToken);

        Invoke(() =>
        {
            GuiUtils.UpdateWorkerStatus(listProcessing, new TextureFileListItem
            {
                FilePath = file,
                Status = nameof(Status.Processing)
            });
        });
    }

    private async Task OnWorkerServiceTerminate(string file, CancellationToken cancellationToken)
    {
        var storedTexture = await _dataService.GetTextureFileAsync(file, cancellationToken);
        storedTexture.FileHashMd5 = CryptoUtils.ComputeFileHash(file);
        storedTexture.IsProcessed = true;
        await _dataService.UpdateTextureFileAsync(storedTexture, cancellationToken);

        Invoke(() =>
        {
            GuiUtils.UpdateWorkerStatus(listProcessing, new TextureFileListItem
            {
                FilePath = storedTexture.FilePath,
                Status = nameof(Status.Finished),
                FileHashMd5 = storedTexture.FileHashMd5,
                IsProcessed = storedTexture.IsProcessed
            });
            stripStatus.Text = $"Processed: {_processedFiles++} of {_totalFiles}";
        });
    }

    private async Task OnWorkerServiceProgress(string file, string message, CancellationToken cancellationToken)
    {
        var storedTexture = await _dataService.GetTextureFileAsync(file, cancellationToken);
        Invoke(() =>
        {
            GuiUtils.UpdateWorkerStatus(listProcessing, new TextureFileListItem
            {
                FilePath = storedTexture.FilePath,
                Status = message,
                FileHashMd5 = storedTexture.FileHashMd5,
                IsProcessed = storedTexture.IsProcessed
            });
        });
    }

    private async Task OnWorkerServiceError(string file, string message, CancellationToken cancellationToken)
    {
        _logger.LogError("Error: {Error}, when processing {File}", message, file);
        var storedTexture = await _dataService.GetTextureFileAsync(file, cancellationToken);
        storedTexture.IsProcessed = false;
        storedTexture.FileHashMd5 = string.Empty;
        await _dataService.UpdateTextureFileAsync(storedTexture, cancellationToken);

        Invoke(() =>
        {
            GuiUtils.UpdateWorkerStatus(listProcessing, new TextureFileListItem
            {
                FilePath = storedTexture.FilePath,
                Status = message,
                FileHashMd5 = storedTexture.FileHashMd5,
                IsProcessed = storedTexture.IsProcessed
            }, Color.Brown);
        });
    }

    #endregion
    
    private void SetupStartProcessingControls()
    {
        StartProcessingTime = DateTime.Now;
        timerProcess.Start();
        btnStop.Enabled = true;
        btnStart.Enabled = false;
        btnClearCache.Enabled = false;
        GuiUtils.DisableCloseButton(Handle);
    }

    private void SetupStopProcessingControls()
    {
        timerProcess.Stop();
        btnStop.Enabled = false;
        btnStart.Enabled = true;
        btnClearCache.Enabled = true;
        GuiUtils.EnableCloseButton(Handle);
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        _logger.LogInformation("Starting processing");
        _isProcessing = true;
        CancellationTokenSrc = new();
        SetupStartProcessingControls();

        _ = Task.Run(async () =>
        {
            try
            {
                Invoke(() =>
                {
                    listProcessing.Items.Clear();
                    listProcessing.BeginUpdate();
                    progressLoading.Show();
                    stripStatus.Text = "Finding textures with missing height maps...";
                });

                var excludedFolders = (await _dataService.GetExcludedFolderListAsync())
                    .Select(f => f.FolderPath).ToList();
                _logger.LogInformation("Extracting normals with missing height maps");
                var normalsNoParallaxList = WorkerUtils
                    .ExtractNormalsMissingParallax(txtGameLocation.Text, excludedFolders)
                    .OrderBy(x => x)
                    .ToList();

                _logger.LogInformation("Found {Count} normals with missing height maps", normalsNoParallaxList.Count);
                _logger.LogInformation("Syncing database with normals list");
                var storedTextures = await _dataService.SyncNormalsList(
                    normalsNoParallaxList,
                    txtGameLocation.Text,
                    OutputLocation,
                    checkKeepOutputInSync.Checked);
                if (!storedTextures.Any())
                {
                    _logger.LogInformation("No missing height maps found. Stopping...");
                    MessageBox.Show(
                        "No missing height maps found!",
                        "No textures",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    stripStatus.Text = "No missing height maps found!";
                    SetupStopProcessingControls();
                    return;
                }

                var storedTexturesItem = storedTextures
                    .Select(t => new TextureFileListItem
                    {
                        FilePath = t.FilePath,
                        Status = t.IsProcessed ?? false ? nameof(Status.Finished) : nameof(Status.None),
                        FileHashMd5 = t.FileHashMd5,
                        IsProcessed = t.IsProcessed
                    })
                    .OrderBy(t => t.FilePath)
                    .ToList();

                stripStatus.Text = "Updating file list...";
                listProcessing.Invoke(() => GuiUtils.UpdateListViewItems(listProcessing, storedTexturesItem));

                var storedProcessedTextures = storedTextures
                    .Where(t => !string.IsNullOrWhiteSpace(t.FileHashMd5))
                    .ToList();

                stripStatus.Text = "Checking hashes...";
                _logger.LogInformation("Checking hashes for {Count} processed textures", storedProcessedTextures.Count);
                var processedTextures = (await storedProcessedTextures
                        .ParallelForEachAsync((texture, _) =>
                            {
                                if (texture.FileHashMd5 != CryptoUtils.ComputeFileHash(texture.FilePath))
                                {
                                    texture.FileHashMd5 = null;
                                    texture.IsProcessed = false;
                                }

                                return Task.FromResult(texture);
                            },
                            MaxHashThreads,
                            CancellationTokenSrc.Token))
                    .Where(t => !string.IsNullOrWhiteSpace(t.FileHashMd5))
                    .ToList();

                _logger.LogInformation(
                    "{Count} textures need to be reprocessed",
                    storedProcessedTextures.Count - processedTextures.Count);
                var texturesListToProcess = storedTextures
                    .Except(processedTextures)
                    .OrderBy(t => t.FilePath)
                    .Select(t => new TextureFileListItem
                    {
                        FilePath = t.FilePath,
                        Status = nameof(Status.None)
                    }).ToList();

                _logger.LogInformation(
                    "Job Summary: Processed {Processed}, Processing {ToProcess}, Total {Total}",
                    processedTextures.Count,
                    texturesListToProcess.Count,
                    storedTexturesItem.Count);
                _totalFiles = storedTexturesItem.Count;
                _processedFiles = processedTextures.Count;
                Invoke(() =>
                {
                    listProcessing.EndUpdate();
                    listProcessing.Refresh();
                    progressLoading.Hide();
                    stripStatus.Text = $"Processed: {_processedFiles++} of {_totalFiles}";
                });

                _logger.LogInformation(
                    "Starting processing {Count} textures using {Threads} threads",
                    texturesListToProcess.Count,
                    numThreadsCount.Value);
                await texturesListToProcess.ParallelForEachAsync(
                    async (texture, token) =>
                    {
                        await _workerService.ProcessNormalTextures(
                            texture.FilePath,
                            OutputLocation,
                            txtGameLocation.Text,
                            trackHeightIntensity.Value,
                            token);
                    },
                    (int)numThreadsCount.Value,
                    CancellationTokenSrc.Token);

                Invoke(() =>
                {
                    stripStatus.Text = "Compressing output...";
                    btnStop.Enabled = false;
                    progressLoading.Show();
                });

                _logger.LogInformation("Compressing output to {OutputLocation}", $"{OutputLocation}.zip");
                await CompressorUtils.CreateZipArchiveAsync(
                    OutputLocation,
                    $"{OutputLocation}.zip",
                    CancellationTokenSrc.Token);
                if (checkRemoveOutput.Checked)
                {
                    _logger.LogInformation("RemoveOutput is checked, removing output folder {OutputLocation}",
                        OutputLocation);
                    Directory.Delete(OutputLocation, true);
                }

                _logger.LogInformation("Process concluded");
                Invoke(() =>
                {
                    progressLoading.Hide();
                    stripStatus.Text = "Process concluded";
                    MessageBox.Show(
                        "Install the output file in ModOrganizer and run PGPatcher (aka ParallaxGen) afterwards",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                });
            }
            catch (Exception ex) when (ex is OperationCanceledException)
            {
                _logger.LogWarning(ex, "Processing stopped by user");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing textures");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
                Invoke(() =>
                {
                    if (progressLoading.Visible)
                    {
                        progressLoading.Hide();
                        listProcessing.EndUpdate();
                        listProcessing.Refresh();
                    }

                    SetupStopProcessingControls();
                });
                MessageBox.Show("Process stopped!", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        });
    }

    private async void FrmMain_LoadAsync(object sender, EventArgs e)
    {
        _logger.LogInformation("Loading application");
        var parentProcessName = ProcessUtils.GetParentProcessNameWmi(Process.GetCurrentProcess().Id);
        if (!string.Equals(parentProcessName, Mo2ProcessName, StringComparison.OrdinalIgnoreCase))
        {
            _logger.LogWarning(
                "Parent process name {ParentProcessName} is not {Mo2ProcessName}",
                parentProcessName, 
                Mo2ProcessName);
            MessageBox.Show(
                "This application must be run from Mod Organizer 2!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Application.Exit();
            return;
        }

        // hide for now
        tabControl1.TabPages.Remove(pageModExclusions);

        _logger.LogInformation("Loading settings");
        var settings = await _dataService.GetSettingsAsync();
        var excludedFolders = await _dataService.GetExcludedFolderListAsync();
        foreach (var folder in excludedFolders)
        {
            listExcludedFolders.Items.Add(folder.FolderPath);
        }

        if (string.IsNullOrWhiteSpace(settings.GameDataFolderLocation))
        {
            _logger.LogInformation("Game data location not set, trying to find it");
            var installPath = RegistryUtils.GetGameInstallLocation();
            if (!string.IsNullOrWhiteSpace(installPath))
            {
                var installFolder = Path.GetDirectoryName(installPath);
                if (!string.IsNullOrWhiteSpace(installFolder))
                {
                    settings.GameDataFolderLocation = Path.Combine(installFolder, "data");
                    _logger.LogInformation("Game data location found: {InstallFolder}", settings.GameDataFolderLocation);
                    await _dataService.UpdateSettings(settings);
                }
            }
        }

        txtGameLocation.Text = !string.IsNullOrWhiteSpace(settings.GameDataFolderLocation)
            ? settings.GameDataFolderLocation
            : "Set game data location folder...";
        txtHeightIntensity.Text = settings.HeightMapIntensity.ToString();
        trackHeightIntensity.Value = settings.HeightMapIntensity;
        numThreadsCount.Value = settings.MaxThreads;

        _logger.LogInformation("Loading textures list");
        var storedTextures = (await _dataService.GetTextureFilesAsync())
            .Select(t => new TextureFileListItem
            {
                FilePath = t.FilePath,
                Status = t.IsProcessed ?? false ? nameof(Status.Finished) : nameof(Status.None),
                FileHashMd5 = t.FileHashMd5,
                IsProcessed = t.IsProcessed
            })
            .OrderBy(t => t.FilePath)
            .ToList();

        GuiUtils.UpdateListViewItems(listProcessing, storedTextures);
        stripStatus.Text = $"Processed: {storedTextures.Count(t => t.IsProcessed ?? false)} of {storedTextures.Count}";
    }

    private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        _logger.LogInformation("Closing application");
        if (!_isProcessing) return;

        await CancellationTokenSrc.CancelAsync();
        while (_isProcessing)
        {
            await Task.Delay(500);
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        btnStop.Enabled = false;
        CancellationTokenSrc.Cancel();
    }

    private void trackHeightIntensity_ValueChanged(object sender, EventArgs e)
    {
        txtHeightIntensity.Text = trackHeightIntensity.Value.ToString();
    }

    private void txtHeightIntensity_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void txtModsLocation_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void txtGameLocation_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void numThreadsCount_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    
    private void txtModsLocation_Click(object sender, EventArgs e)
    {
        if (dlgInputFolder.ShowDialog() == DialogResult.OK)
            txtModsLocation.Text = dlgInputFolder.SelectedPath;
    }

    private void txtGameLocation_Click(object sender, EventArgs e)
    {
        if (dlgInputFolder.ShowDialog() == DialogResult.OK)
            txtGameLocation.Text = dlgInputFolder.SelectedPath;
    }

    private void ctxProcessing_Opened(object sender, EventArgs e)
    {
        openNormalMenuItem.Enabled = openHeightMenuItem.Enabled = listProcessing.SelectedItems.Count == 1;
    }

    private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var selectedFile = listProcessing.SelectedItems[0].Text;
        if (!File.Exists(selectedFile))
        {
            _logger.LogInformation("Can't preview, the file {File} doesn't exist", selectedFile);
            MessageBox.Show("The file doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var visualizer = new FrmVisualizer(_logger, selectedFile);
        visualizer.ShowDialog(this);
    }

    private async void openDestinationFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var sourceFolder = Path.GetDirectoryName(listProcessing.SelectedItems[0].Text)!;
        var destinationFolder = Path.Combine(
            AppContext.BaseDirectory,
            sourceFolder.Replace(txtGameLocation.Text, OutputLocation));
        if (!Directory.Exists(destinationFolder))
        {
            _logger.LogInformation("The height map hasn't been created yet or doesn't exist");
            MessageBox.Show(
                "The height map hasn't been created yet or doesn't exist!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        await ProcessUtils.ExecuteProcess("explorer.exe", $"\"{destinationFolder}\"", fireAndForget: true);
    }

    private async void txtExcludedFolder_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != (char)Keys.Enter) return;

        if (!string.IsNullOrWhiteSpace(txtExcludedFolder.Text))
        {
            listExcludedFolders.Items.Add(txtExcludedFolder.Text);
            await _dataService.AddExcludedFolderAsync(new ExcludedFolder
            {
                FolderPath = txtExcludedFolder.Text
            });
            txtExcludedFolder.Clear();
            txtExcludedFolder.Focus();
        }
        e.Handled = true;
    }

    private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var foldersToExclude = new List<string>();
        foreach (ListViewItem item in listExcludedFolders.SelectedItems)
        {
            listExcludedFolders.Items.Remove(item);
            foldersToExclude.Add(item.Text);
        }

        await _dataService.RemoveExcludedFolderListAsync(foldersToExclude);
    }

    private async void btnSaveSettings_Click(object sender, EventArgs e)
    {
        var settings = await _dataService.GetSettingsAsync();
        settings.HeightMapIntensity = trackHeightIntensity.Value;
        settings.MaxThreads = (int)numThreadsCount.Value;
        settings.GameDataFolderLocation = txtGameLocation.Text;
        await _dataService.UpdateSettings(settings);
        MessageBox.Show("Settings saved!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(
                "Are you sure you want to reset settings to default?", "Reset settings",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        var settings = new Settings();
        trackHeightIntensity.Value = settings.HeightMapIntensity;
        numThreadsCount.Value = settings.MaxThreads;
        checkKeepOutputInSync.Checked = true;
        checkRemoveOutput.Checked = false;
    }

    private void ctxExcludedFolders_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        ctxExcludedFolders.Enabled = listExcludedFolders.SelectedItems.Count >= 1;
    }

    private async void excludeFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var selectedFiles = new List<string>();
        foreach (ListViewItem item in listProcessing.SelectedItems)
        {
            selectedFiles.Add(item.Text);
        }

        var foldersToExclude = selectedFiles
            .Select(file => FileSystemUtils.ToTexturePath(file, txtGameLocation.Text))
            .Distinct();

        await _dataService.AddExcludedFolderListAsync(foldersToExclude
            .Select(f => new ExcludedFolder { FolderPath = f }));
        var excludedFolders = await _dataService.GetExcludedFolderListAsync();
        GuiUtils.UpdateListViewItems(
            listExcludedFolders, 
            excludedFolders.Select(f => f.FolderPath).ToList());
    }

    private void timerProcess_Tick(object sender, EventArgs e)
    {
        var elapsed = DateTime.Now - StartProcessingTime!;
        stripTimer.Text = $"Elapsed: {elapsed.Value.Hours:D2}:{elapsed.Value.Minutes:D2}:{elapsed.Value.Seconds:D2}";
    }

    private void filePathToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var paths = listProcessing.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => item.Text)
            .ToList();
        Clipboard.SetText(string.Join(Environment.NewLine, paths));
    }

    private void statusToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var statuses = listProcessing.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => item.SubItems[1].Text)
            .ToList();
        Clipboard.SetText(string.Join(Environment.NewLine, statuses));
    }

    private void hashToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var hashes = listProcessing.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => item.SubItems[2].Text)
            .ToList();
        Clipboard.SetText(string.Join(Environment.NewLine, hashes));
    }

    private void lineToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var lines = listProcessing.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => string.Join("   |   ", item.Text, item.SubItems[1].Text, item.SubItems[2].Text))
            .ToList();
        Clipboard.SetText(string.Join(Environment.NewLine, lines));
    }

    private async void btnClearCache_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(
                "Are you sure you want to clear the cache?. The output folder and textures cache will be removed",
                "Clear cache",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        _logger.LogInformation("Clearing cache by user request");
        try
        {
            await _dataService.ClearTextureFilesAsync();
            if (Directory.Exists(OutputLocation))
                Directory.Delete(OutputLocation, true);

            listProcessing.Items.Clear();
            stripStatus.Text = "Cache cleared";
            MessageBox.Show("Cache cleared!", "Cache", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error clearing cache");
            MessageBox.Show(
                "Error clearing cache. Check the log file for more details",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}