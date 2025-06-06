﻿using System.Diagnostics;
using System.IO.Compression;
using Microsoft.Extensions.Logging;
using SkyMapper.Services;

namespace SkyMapper.Utils;

public static class CompressorUtils
{
    private static ILogger<WorkerService> Logger => ServiceLocator.LocateService<ILogger<WorkerService>>();
    
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
            Logger.LogError(e, "Error creating ZIP archive");
            throw;
        }
    }
}