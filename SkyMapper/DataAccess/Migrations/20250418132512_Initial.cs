using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyMapper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcludedFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderPath = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludedFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameDataFolderLocation = table.Column<string>(type: "varchar(500)", nullable: true),
                    MaxThreads = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightMapIntensity = table.Column<int>(type: "INTEGER", nullable: false),
                    SyncOutputFolder = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextureFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "varchar(500)", nullable: false),
                    IsProcessed = table.Column<bool>(type: "INTEGER", nullable: false),
                    FileHashMd5 = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextureFiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExcludedFolders",
                columns: new[] { "Id", "FolderPath" },
                values: new object[,]
                {
                    { 1, "textures\\lod" },
                    { 2, "textures\\interface" },
                    { 3, "textures\\DynDOLOD" },
                    { 4, "textures\\actors\\character\\facegendata" },
                    { 5, "textures\\chargen" },
                    { 6, "textures\\cubemap" },
                    { 7, "textures\\cubemaps" },
                    { 8, "textures\\terrain" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "GameDataFolderLocation", "HeightMapIntensity", "MaxThreads", "SyncOutputFolder" },
                values: new object[] { 1, null, -88, 5, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcludedFolders");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "TextureFiles");
        }
    }
}
