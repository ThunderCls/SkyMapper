using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMapper.DataAccess.Models;

public class Settings
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(500)")] public string? GameDataFolderLocation { get; set; }
    public int MaxThreads { get; set; } = 5;
    public int HeightMapIntensity { get; set; } = -20;
    public int HeightMapPasses { get; set; } = 128;
    public int HeightMapMaxSteps { get; set; } = 1;
    public bool SyncOutputFolder { get; set; } = true;
    public bool ReprocessFailedTextures { get; set; }
}
