using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMapper.DataAccess.Models;

public class TextureFile
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(500)")] public required string FilePath { get; set; }
    public bool IsProcessed { get; set; }
    [Column(TypeName = "varchar(50)")] public string? FileHashMd5 { get; set; }
    public bool IsFailed { get; set; }
    [Column(TypeName = "varchar(255)")] public string? FailureError { get; set; }
}
