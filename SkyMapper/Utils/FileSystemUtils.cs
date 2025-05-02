namespace SkyMapper.Utils;

public static class FileSystemUtils
{
    public static string ToOutputParallaxPath(string filePath, string inputBaseLocation, string outputLocation)
    {
        var fileName = Path.GetFileName(filePath);
        var directory = Path.GetDirectoryName(filePath)!;
        var outputPath = directory.Replace(inputBaseLocation, outputLocation);
        return Path.Combine(outputPath, fileName.Replace("_n.dds", "_p.dds", StringComparison.OrdinalIgnoreCase));
    }

    public static string ToTexturePath(string file, string gameLocation) =>
        Path.GetDirectoryName(file.Replace($"{gameLocation}{Path.DirectorySeparatorChar}", string.Empty))!;

    public static string ToTextureFilePath(string file, string gameLocation) =>
        file.Replace($"{gameLocation}{Path.DirectorySeparatorChar}", string.Empty);
}
