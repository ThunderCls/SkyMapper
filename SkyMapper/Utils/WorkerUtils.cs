using System.Text.RegularExpressions;

namespace SkyMapper.Utils;

public static class WorkerUtils
{
    private static string HiddenFolder = ".mohidden";
    
    public static List<string> ExtractNormalsMissingParallax(string rootFolder, List<string> excludedFolders)
    {
        var normalsMissingParallax = new List<string>();
        var textures = Directory
            .GetFiles(Path.Combine(rootFolder, "textures"), "*.*", SearchOption.AllDirectories)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var filteredTextures = textures
            .Where(texture =>
                Regex.IsMatch(texture, @"^.*_n\.dds$", RegexOptions.IgnoreCase) &&
                !excludedFolders.Any(excludedFolder =>
                {
                    var baseTexturePath = Path.GetDirectoryName(
                        texture.Replace($"{rootFolder}{Path.DirectorySeparatorChar}", string.Empty))!;
                    return baseTexturePath.Contains(excludedFolder);
                }) &&
                !texture.Contains(HiddenFolder, StringComparison.OrdinalIgnoreCase));

        foreach (var normal in filteredTextures)
        {
            var parallaxTexture = Regex.Replace(normal, @"_n\.dds$", "_p.dds", RegexOptions.IgnoreCase);
            if (!textures.Contains(parallaxTexture))
                normalsMissingParallax.Add(normal);
        }

        return normalsMissingParallax;
    }
}