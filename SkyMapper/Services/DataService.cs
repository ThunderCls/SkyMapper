using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkyMapper.DataAccess;
using SkyMapper.DataAccess.Models;
using SkyMapper.Utils;

namespace SkyMapper.Services;

public class DataService
{
    private readonly ILogger<DataService> _logger;
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DataService(
        ILogger<DataService> logger,
        IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public async Task<List<ExcludedFolder>> GetExcludedFolderListAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.ExcludedFolders.ToListAsync(cancellationToken);
    }

    public async Task AddExcludedFolderAsync(ExcludedFolder folder, CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.ExcludedFolders.Add(folder);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveExcludedFolderListAsync(
        List<string> folderList, 
        CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var existingFolderList = await context.ExcludedFolders
            .Where(f => folderList.Contains(f.FolderPath))
            .ToListAsync(cancellationToken);
        if (!existingFolderList.Any())
            return;

        context.ExcludedFolders.RemoveRange(existingFolderList);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Settings> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Settings.FirstOrDefaultAsync(cancellationToken) ?? new Settings();
    }

    public async Task UpdateSettings(Settings settings, CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.Settings.Update(settings);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TextureFile>> GetTextureFilesAsync(CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.TextureFiles.ToListAsync(cancellationToken);
    }

    public async Task AddTextureFileListAsync(
        IEnumerable<TextureFile> textureFiles, 
        CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.AddRange(textureFiles);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task RemoveTextureFileListAsync(
        IEnumerable<TextureFile> textureFiles, 
        CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.RemoveRange(textureFiles);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdateTextureFileAsync(TextureFile textureFile, CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.Update(textureFile);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TextureFile> GetTextureFileAsync(string textureFile, CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.TextureFiles.FirstAsync(f => f.FilePath == textureFile, cancellationToken);
    }

    internal async Task AddExcludedFolderListAsync(
        IEnumerable<ExcludedFolder> folders, 
        CancellationToken cancellationToken = default)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.ExcludedFolders.AddRange(folders);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task ClearTextureFilesAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.TextureFiles.RemoveRange(context.TextureFiles);
        await context.SaveChangesAsync();
    }
    
    public async Task<List<TextureFile>> SyncNormalsList(
        List<string> normalsNoParallaxList,
        string gameLocation,
        string outputLocation,
        bool syncOutput = true)
    {
        var storedTextures = await GetTextureFilesAsync();
        var missingTextures = normalsNoParallaxList
            .Where(t => !storedTextures.Any(s =>
                string.Equals(s.FilePath, t, StringComparison.OrdinalIgnoreCase)))
            .ToList();
        if (missingTextures.Any())
        {
            _logger.LogInformation(
                "Adding {Count} missing textures to database", 
                missingTextures.Count);
            await AddTextureFileListAsync(normalsNoParallaxList
                .Select(n => new TextureFile { FilePath = n }));
        }

        var nonExistentTextures = storedTextures
            .Where(t => !normalsNoParallaxList.Any(s =>
                string.Equals(s, t.FilePath, StringComparison.OrdinalIgnoreCase)))
            .ToList();
        if (nonExistentTextures.Any())
        {
            _logger.LogInformation(
                "Removing {Count} non-existent textures from database", 
                nonExistentTextures.Count);
            await RemoveTextureFileListAsync(nonExistentTextures);
            if (syncOutput)
            {
                _logger.LogInformation(
                    "SyncOutput is enabled. Removing {Count} non-existent textures from output folder", 
                    nonExistentTextures.Count);
                foreach (var nonExistentTexture in nonExistentTextures)
                {
                    var outputFile = FileSystemUtils.ToOutputParallaxPath(
                        nonExistentTexture.FilePath,
                        gameLocation,
                        outputLocation);
                    
                    try
                    {
                        if (File.Exists(outputFile))
                            File.Delete(outputFile);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }
        }

        return await GetTextureFilesAsync();
    }
}
