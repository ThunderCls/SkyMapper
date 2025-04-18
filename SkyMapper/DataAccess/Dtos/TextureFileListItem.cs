namespace SkyMapper.DataAccess.Dtos;

public class TextureFileListItem
{
    public required string FilePath { get; set; }
    public string? Status { get; set; }
    public string? FileHashMd5 { get; set; }
    public bool? IsProcessed { get; set; }
}