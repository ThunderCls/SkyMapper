using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SkyMapper.Utils;

namespace SkyMapper.Services;

public class WorkerService
{
    private readonly ILogger<WorkerService> _logger;
    private readonly string _normalToHeightExecutable;
    
    public event Func<string, CancellationToken, Task>? WorkerInit;
    public event Func<string, CancellationToken, Task>? WorkerTerminate;
    public event Func<string, string, CancellationToken, Task>? WorkerProgress;
    public event Func<string, string, CancellationToken, Task>? WorkerError;

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

    private async Task OnWorkerProgress(string file, string message, CancellationToken cancellationToken = default)
    {
        if (WorkerProgress is not null)
            await WorkerProgress.Invoke(file, message, cancellationToken);
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

    #endregion

    // Processing
    // 1- Convert normal map to PNG and save in the global output (modname->textures->keep the same directory structure)
    // 2- Execute NormalToHeight.exe with the PNG file
    // 3- Set the intensity of the height map
    // 4- Convert the height map to DDS
    // 5- Delete all PNG files and leave only the height map DDS files
    // 6- When all mods are processed, pack the output directory into a zip file
    public async Task ProcessNormalTextures(
        string file, 
        string outputLocation, 
        string gameDataLocation,
        double heightIntensity,
        CancellationToken cancellationToken)
    {
        try
        {
            await OnWorkerInit(file, cancellationToken);
            var destinationFile = Path.Combine(outputLocation,
                file.Replace($"{gameDataLocation}{Path.DirectorySeparatorChar}", string.Empty));
            var destinationDirectory = Path.GetDirectoryName(destinationFile)!;
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            await OnWorkerProgress(file, "Changing texture format", cancellationToken);
            var pngImage = await TextureUtils.ConvertToPng(file, destinationDirectory);
            var parallaxImage = Regex.Replace(pngImage, @"_n\.png$", "_p.png", RegexOptions.IgnoreCase);

            await OnWorkerProgress(file, "Creating height map", cancellationToken);
            await ProcessUtils.ExecuteProcess($"\"{_normalToHeightExecutable}\"",
                $"\"{Path.Combine(AppContext.BaseDirectory, pngImage)}\" "+
                $"\"{Path.Combine(AppContext.BaseDirectory, parallaxImage)}\" " +
                "-scale 100.00 -numPasses 32 -normalScale 1.00 -maxStepHeight 1 " + 
                "-mapping XrYfgZb -zrange full -edgeMode Wrap", hidden: true);
            await TextureUtils.SetHeightMapIntensity(parallaxImage, heightIntensity);

            await OnWorkerProgress(file, "Changing texture format", cancellationToken);
            await TextureUtils.ConvertToDds(parallaxImage);

            await OnWorkerProgress(file, "Removing temporary files", cancellationToken);
            File.Delete(pngImage);
            File.Delete(parallaxImage);

            await OnWorkerTerminate(file, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "WorkerService failed");
            await OnWorkerError(file, e.Message, cancellationToken);
        }
    }
    
    //public static void ProcessModTextures(string texture, string destinationFolder)
    //{
    //    var bsaTextureFiles = new Dictionary<string, List<string>>();
    //    var looseTextureFiles = new List<string>();
    //    var inputFolder = Directory.GetParent(texture)!.FullName;
    //    var files = Directory.GetFiles(texture).ToList();

    //    if (files.Exists(f => Path.GetExtension(f) == ".bsa"))
    //    {
    //        foreach (var bsaFile in files.Where(f => Path.GetExtension(f) == ".bsa"))
    //        {
    //            bsaTextureFiles.TryAdd(bsaFile, BsaService.GetFiles(bsaFile, [@"^.*_n\.dds$", @"^.*_p\.dds$"]));
    //        }
    //    }
    //    bsaTextureFiles = ExtractMissingParallaxNormals(bsaTextureFiles);

    //    looseTextureFiles.AddRange(DirectoryService.GetFiles(texture, [@"^.*_n\.dds$", @"^.*_p\.dds$"]));
    //    looseTextureFiles = ExtractMissingParallaxNormals(looseTextureFiles);

    //    if (bsaTextureFiles.Any())
    //    {
    //        foreach(var bsaFile in bsaTextureFiles.Keys)
    //        {
    //            BsaService.ExtractFiles(bsaFile, destinationFolder, bsaTextureFiles.GetValueOrDefault(bsaFile) ?? []);
    //        }
    //    }

    //    if (looseTextureFiles.Any())
    //    {
    //        ProcessTextures(looseTextureFiles, inputFolder, destinationFolder);
    //    }
    //}

    //private static List<string> ExtractMissingParallaxNormals(Dictionary<string, List<string>> textures)
    //{
    //    var missingParallaxTextures = new List<string>();
    //}
}
