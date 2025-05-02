using Microsoft.EntityFrameworkCore;
using SkyMapper.DataAccess.Models;

namespace SkyMapper.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Settings> Settings { get; set; }
    public DbSet<TextureFile> TextureFiles { get; set; }
    public DbSet<Exclusions> Exclusions { get; set; }

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
        modelBuilder.Entity<Exclusions>(e =>
        {
            e.HasData(
                new Exclusions { Id = 1, Pattern = @"textures\\lod\\" },
                new Exclusions { Id = 2, Pattern = @"textures\\interface\\" },
                new Exclusions { Id = 3, Pattern = @"textures\\DynDOLOD\\" },
                new Exclusions { Id = 4, Pattern = @"textures\\terrain\\" },
                new Exclusions { Id = 5, Pattern = @"textures\\.*\\chargen\\" },
                new Exclusions { Id = 6, Pattern = @"textures\\.*\\cubemap.*\\" },
                new Exclusions { Id = 7, Pattern = @"textures\\.*\\facegen.*\\" },
                new Exclusions { Id = 8, Pattern = @"textures\\.*\\*hair.*\\" },
                new Exclusions { Id = 9, Pattern = @"textures\\.*\\*brow.*\\" },
                new Exclusions { Id = 10, Pattern = @"textures\\.*\\mouth\\" },
                new Exclusions { Id = 11, Pattern = @"textures\\.*\\*eyes\\" },
                new Exclusions { Id = 12, Pattern = @"textures\\.*\\*beard.*\\" },
                new Exclusions { Id = 13, Pattern = @"textures\\.*\\*lashes\\" },
                new Exclusions { Id = 14, Pattern = @"textures\\.*\\*gash\\" },
                new Exclusions { Id = 15, Pattern = @"textures\\.*\\*tattoo\\" },
                new Exclusions { Id = 16, Pattern = @"textures\\.*\\*skin.*\\" }
            );
        });

        base.OnModelCreating(modelBuilder);
    }
}
