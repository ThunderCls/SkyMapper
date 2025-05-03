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

    public async Task<List<Exclusions>> GetExclusionListAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Exclusions.ToListAsync(cancellationToken);
    }

    public async Task AddExclusionAsync(Exclusions exclusion, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.Exclusions.Add(exclusion);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddExclusionListAsync(
        IEnumerable<Exclusions> exclusions,
        CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.Exclusions.AddRange(exclusions);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveExclusionListAsync(List<string> exclusionList, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var existingFolderList = await context.Exclusions
            .Where(f => exclusionList.Contains(f.Pattern))
            .ToListAsync(cancellationToken);
        if (!existingFolderList.Any())
            return;

        context.Exclusions.RemoveRange(existingFolderList);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Settings> GetSettingsAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Settings.FirstOrDefaultAsync(cancellationToken) ?? new Settings();
    }

    public async Task UpdateSettings(Settings settings, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.Settings.Update(settings);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TextureFile>> GetTextureFileListAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.TextureFiles.ToListAsync(cancellationToken);
    }

    public async Task<TextureFile> GetTextureFileAsync(string textureFile, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await context.TextureFiles.FirstAsync(f => f.FilePath == textureFile, cancellationToken);
    }

    public async Task AddTextureFileListAsync(IEnumerable<TextureFile> textureFiles, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.AddRange(textureFiles);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task RemoveTextureFileListAsync(IEnumerable<TextureFile> textureFiles, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.RemoveRange(textureFiles);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdateTextureFileAsync(TextureFile textureFile, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.Update(textureFile);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task ClearTextureFilesAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        context.TextureFiles.RemoveRange(context.TextureFiles);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<TextureFile>> SyncNormalsList(
        List<string> normalsNoParallaxList,
        string gameLocation,
        string outputLocation,
        bool syncOutput = true,
        CancellationToken cancellationToken = default)
    {
        var storedTextures = await GetTextureFileListAsync(cancellationToken);
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
                .Select(n => new TextureFile { FilePath = n }), cancellationToken);
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
            await RemoveTextureFileListAsync(nonExistentTextures, cancellationToken);
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

        return await GetTextureFileListAsync(cancellationToken);
    }
}
