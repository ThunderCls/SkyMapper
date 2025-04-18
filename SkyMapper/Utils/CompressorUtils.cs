using System.Diagnostics;
using System.IO.Compression;

namespace SkyMapper.Utils;

public static class CompressorUtils
{
    public static async Task CreateZipArchiveAsync(
        string sourceFolder, 
        string zipFileName, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Ensure the directory for the zip file exists
            var zipDirectory = Path.GetDirectoryName(zipFileName);
            if (!string.IsNullOrEmpty(zipDirectory) && !Directory.Exists(zipDirectory))
                Directory.CreateDirectory(zipDirectory);
    
            // Delete existing zip if it exists
            if (File.Exists(zipFileName))
                File.Delete(zipFileName);
    
            await Task.Run(() => {
                ZipFile.CreateFromDirectory(sourceFolder, zipFileName);
            }, cancellationToken);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error creating ZIP archive: {e}");
            throw;
        }
    }
}