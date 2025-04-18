using Microsoft.EntityFrameworkCore;
using SkyMapper.DataAccess.Models;

namespace SkyMapper.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Settings> Settings { get; set; }
    public DbSet<TextureFile> TextureFiles { get; set; }
    public DbSet<ExcludedFolder> ExcludedFolders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=data.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Settings>(e =>
        {
            e.HasData(new Settings
            {
                Id = 1,
                MaxThreads = 5,
                HeightMapIntensity = -88
            });
        });

        modelBuilder.Entity<ExcludedFolder>(e =>
        {
            e.HasData(
                new ExcludedFolder { Id = 1, FolderPath = @"textures\lod" },
                new ExcludedFolder { Id = 2, FolderPath = @"textures\interface" },
                new ExcludedFolder { Id = 3, FolderPath = @"textures\DynDOLOD" },
                new ExcludedFolder { Id = 4, FolderPath = @"textures\actors\character\facegendata" },
                new ExcludedFolder { Id = 5, FolderPath = @"textures\chargen" },
                new ExcludedFolder { Id = 6, FolderPath = @"textures\cubemap" },
                new ExcludedFolder { Id = 7, FolderPath = @"textures\cubemaps" },
                new ExcludedFolder { Id = 8, FolderPath = @"textures\terrain" }
            );
        });

        base.OnModelCreating(modelBuilder);
    }
}
