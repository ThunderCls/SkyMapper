using System.Text.RegularExpressions;

namespace SkyMapper.Utils;

public static class WorkerUtils
{
    private static readonly string HiddenFolder = ".mohidden";
    
    public static List<string> ExtractNormalsMissingParallax(string rootFolder, IEnumerable<string> exclusions)
    {
        var normalsMissingParallax = new List<string>();
        var textures = Directory
            .GetFiles(Path.Combine(rootFolder, "textures"), "*.*", SearchOption.AllDirectories)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var filteredTextures = textures
            .Where(texture =>
                Regex.IsMatch(texture, @"^.*_n\.dds$", RegexOptions.IgnoreCase) &&
                !texture.Contains(HiddenFolder, StringComparison.OrdinalIgnoreCase) &&
                !exclusions.Any(exclusion =>
                {
                    var baseTextureFilePath = texture
                        .Replace($"{rootFolder}{Path.DirectorySeparatorChar}", string.Empty);
                    return Regex.IsMatch(baseTextureFilePath, exclusion, RegexOptions.IgnoreCase);
                }));

        foreach (var normal in filteredTextures)
        {
            var parallaxTexture = Regex.Replace(normal, @"_n\.dds$", "_p.dds", RegexOptions.IgnoreCase);
            if (!textures.Contains(parallaxTexture))
                normalsMissingParallax.Add(normal);
        }

        return normalsMissingParallax;
    }
}