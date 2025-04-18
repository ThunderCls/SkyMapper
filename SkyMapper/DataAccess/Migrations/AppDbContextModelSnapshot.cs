﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkyMapper.DataAccess;

#nullable disable

namespace SkyMapper.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.15");

            modelBuilder.Entity("SkyMapper.DataAccess.Models.ExcludedFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FolderPath")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ExcludedFolders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FolderPath = "textures\\lod"
                        },
                        new
                        {
                            Id = 2,
                            FolderPath = "textures\\interface"
                        },
                        new
                        {
                            Id = 3,
                            FolderPath = "textures\\DynDOLOD"
                        },
                        new
                        {
                            Id = 4,
                            FolderPath = "textures\\actors\\character\\facegendata"
                        },
                        new
                        {
                            Id = 5,
                            FolderPath = "textures\\chargen"
                        },
                        new
                        {
                            Id = 6,
                            FolderPath = "textures\\cubemap"
                        },
                        new
                        {
                            Id = 7,
                            FolderPath = "textures\\cubemaps"
                        },
                        new
                        {
                            Id = 8,
                            FolderPath = "textures\\terrain"
                        });
                });

            modelBuilder.Entity("SkyMapper.DataAccess.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameDataFolderLocation")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("HeightMapIntensity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxThreads")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HeightMapIntensity = -88,
                            MaxThreads = 5
                        });
                });

            modelBuilder.Entity("SkyMapper.DataAccess.Models.TextureFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileHashMd5")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool?>("IsProcessed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TextureFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
