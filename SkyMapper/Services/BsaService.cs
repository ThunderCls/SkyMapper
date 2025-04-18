using System.Text;
using System.Text.RegularExpressions;
using SharpBSABA2;

namespace SkyMapper.Services;

public class BsaService
{
    public static List<string> GetFiles(string bsaFile, List<string> filePatterns)
    {
        var bsaArchive = OpenArchive(bsaFile);
        return bsaArchive is not null
            ? bsaArchive.Files
                .Where(x => filePatterns.Any(filter => Regex.IsMatch(x.FullPath, filter, RegexOptions.IgnoreCase)))
                .Select(x => x.FullPath)
                .ToList()
            : [];
    }

    public static void ExtractFiles(string bsaFile, string destination, List<string> files)
    {
        var bsaArchive = OpenArchive(bsaFile);
        var archives = bsaArchive is not null
            ? bsaArchive.Files
                .Where(x => files.Contains(x.FullPath))
                .ToList()
            : [];

        foreach (var archive in archives)
        {
            archive.Extract(destination, true);
        }
    }

    public static void ExtractFilePatterns(string bsaFile, string destination, List<string> filePatterns)
    {
        var bsaArchive = OpenArchive(bsaFile);
        var archives = bsaArchive is not null
            ? bsaArchive.Files
                .Where(x => filePatterns.Any(filter => Regex.IsMatch(x.FullPath, filter, RegexOptions.IgnoreCase)))
                .ToList()
            : [];

        foreach (var archive in archives)
        {
            archive.Extract(destination, true);
        }
    }

    static Archive? OpenArchive(string file)
    {
        Archive? archive;
        string extension = Path.GetExtension(file);

        switch (extension.ToLower())
        {
            case ".bsa":
            case ".dat":
                archive = new SharpBSABA2.BSAUtil.BSA(file, Encoding.UTF8);
                break;
            case ".ba2":
                archive = new SharpBSABA2.BA2Util.BA2(file, Encoding.UTF8);
                break;
            default:
                return null;
        }

        archive.MatchLastWriteTime = true;
        archive.Files.Sort((a, b) => string.CompareOrdinal(a.LowerPath, b.LowerPath));
        return archive;
    }
    
    //private void ExtractBsaNormals(string bsaPath, string outputDirectory)
    //{
    //    // Load the BSA file
    //    using var bsa = new BsaFile(bsaPath);

    //    // Extract all files with the ".dds" extension
    //    foreach (var entry in bsa.Entries)
    //    {
    //        if (entry.Name.EndsWith(".dds", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var outputFilePath = Path.Combine(outputDirectory, entry.Name);
    //            File.WriteAllBytes(outputFilePath, entry.Data);
    //        }
    //    }
    //}
}