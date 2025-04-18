using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMapper.DataAccess.Models;

public class ExcludedFolder
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(500)")]
    public required string FolderPath { get; set; }
}
