using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMapper.DataAccess.Models;

public class Settings
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string? GameDataFolderLocation { get; set; }
    public int MaxThreads { get; set; } = 5;
    public int HeightMapIntensity { get; set; } = -88;
}
