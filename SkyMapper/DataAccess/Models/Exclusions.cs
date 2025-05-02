using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMapper.DataAccess.Models;

public class Exclusions
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(500)")] public required string Pattern { get; set; }
}
