using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SkyMapper.Utils;

namespace SkyMapper.Services;

public class WorkerService
{
    private readonly ILogger<WorkerService> _logger;
    private readonly string _normalToHeightExecutable;
    private WorkerArgs? _args;
    
    public event Func<string, CancellationToken, Task>? WorkerInit;
    public event Func<string, CancellationToken, Task>? WorkerTerminate;
    public event Action<string, string>? WorkerProgress;
    public event Func<string, string, CancellationToken, Task>? WorkerError;

    public class WorkerArgs
    {
        public string File { get; set; } = string.Empty;
        public string OutputLocation { get; set; } = string.Empty;
        public string GameDataLocation { get; set; } = string.Empty;
        public double HeightIntensity { get; set; }
        public int HeightNumberPasses { get; set; }
        public int HeightMaxSteps { get; set; }
        public Form SynchronizingObject { get; set; } = null!;
        public CancellationToken CancellationToken { get; set; }
    }
    
    public WorkerService(ILogger<WorkerService> logger)
    {
        _logger = logger;
        _normalToHeightExecutable = Path.Combine(
            AppContext.BaseDirectory,
            "ThirdParty",
            "NormalToHeight",
            "NormalToHeight.exe");
    }
    
    #region Events

    private void OnWorkerProgress(string file, string message)
    {
        if (WorkerProgress is not null)
            WorkerProgress.Invoke(file, message);
    }

    private async Task OnWorkerError(string file, string message, CancellationToken cancellationToken = default)
    {
        if (WorkerError is not null)
            await WorkerError.Invoke(file, message, cancellationToken);
    }

    private async Task OnWorkerInit(string file, CancellationToken cancellationToken = default)
    {
        if (WorkerInit is not null)
            await WorkerInit.Invoke(file, cancellationToken);
    }

    private async Task OnWorkerTerminate(string file, CancellationToken cancellationToken = default)
    {
        if (WorkerTerminate is not null)
            await WorkerTerminate.Invoke(file, cancellationToken);
    }

    private void OnProcessExecutionError(string message)
    {
        _logger.LogError("Process execution for {File} failed with error: {Message}", _args!.File, message);
    }
    
    private void OnProcessExecutionProgress(string message)
    {
        OnWorkerProgress(_args!.File, message);
    }
    
    #endregion

    // Processing
    // 1- Convert normal map to PNG and save in the global output (modname->textures->keep the same directory structure)
    // 2- Execute NormalToHeight.exe with the PNG file
    // 3- Set the intensity of the height map
    // 4- Convert the height map to DDS
    // 5- Delete all PNG files and leave only the height map DDS files
    // 6- When all mods are processed, pack the output directory into a zip file
    public async Task ProcessNormalTextures(WorkerArgs args)
    {
        _args = args;
        var normalImage = string.Empty;
        var parallaxImage = string.Empty;
        try
        {
            await OnWorkerInit(args.File, args.CancellationToken);
            var destinationFile = Path.Combine(args.OutputLocation,
                args.File.Replace($"{args.GameDataLocation}{Path.DirectorySeparatorChar}", string.Empty));
            var destinationDirectory = Path.GetDirectoryName(destinationFile)!;
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            OnWorkerProgress(args.File, "Changing texture format");
            normalImage = await TextureUtils.ConvertToPng(args.File, destinationDirectory);
            if (!File.Exists(normalImage))
            {
                _logger.LogError(
                    "Error changing format of normal map: {NormalImage}. Trying backup method using DDSMaterialCreator",
                    normalImage);
                var textureToImageArgs = new DdsMaterialCreatorUtils.TextureToImageArgs
                {
                    TexturePath = args.File,
                    OutputPath = destinationDirectory,
                    HighQuality = true,
                    ArchaicFormat = false
                };
                DdsMaterialCreatorUtils.TextureToImage(ref textureToImageArgs, out var errorMessage);
                normalImage = Path.Combine(destinationDirectory, Path.GetFileNameWithoutExtension(args.File) + ".png");
                if (!File.Exists(normalImage))
                {
                    throw new ApplicationException($"Error changing format of normal map: {normalImage}. Details: {errorMessage}");
                }
            }

            parallaxImage = Regex.Replace(normalImage, @"_n\.png$", "_p.png", RegexOptions.IgnoreCase);

            OnWorkerProgress(args.File, "Creating height map");
            await ProcessUtils.ExecuteProcessAsync(
                _normalToHeightExecutable,
                $"\"{Path.Combine(AppContext.BaseDirectory, normalImage)}\" " +
                $"\"{Path.Combine(AppContext.BaseDirectory, parallaxImage)}\" " +
                $"-scale 100 -numPasses {args.HeightNumberPasses} -normalScale 1 -maxStepHeight {args.HeightMaxSteps} -normalise " +
                "-mapping XrYfgZb -zrange full -edgeMode Wrap",
                args.SynchronizingObject,
                // OnProcessExecutionProgress,
                errorAction: OnProcessExecutionError);
            if (!File.Exists(parallaxImage))
            {
                throw new ApplicationException($"Parallax map image couldn't be created: {parallaxImage}");
            }

            await TextureUtils.SetHeightMapIntensity(parallaxImage, args.HeightIntensity);

            OnWorkerProgress(args.File, "Changing texture format");
            await TextureUtils.ConvertToDds(parallaxImage);
        }
        catch (Exception e)
        {
            CleanTemporaryFiles(normalImage, parallaxImage);
            await OnWorkerError(args.File, e.Message, args.CancellationToken);
            return;
        }
        
        OnWorkerProgress(args.File, "Removing temporary files");
        CleanTemporaryFiles(normalImage, parallaxImage);
        await OnWorkerTerminate(args.File, args.CancellationToken);
    }

    private static void CleanTemporaryFiles(string normalImage, string parallaxImage)
    {
        try
        {
            if (File.Exists(normalImage))
                File.Delete(normalImage);
            if (File.Exists(parallaxImage))
                File.Delete(parallaxImage);
        }
        catch {}
    }
}
