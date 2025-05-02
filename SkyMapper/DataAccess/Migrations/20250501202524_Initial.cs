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
                name: "Exclusions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pattern = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exclusions", x => x.Id);
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
                    HeightMapPasses = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightMapMaxSteps = table.Column<int>(type: "INTEGER", nullable: false),
                    SyncOutputFolder = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReprocessFailedTextures = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    FileHashMd5 = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsFailed = table.Column<bool>(type: "INTEGER", nullable: false),
                    FailureError = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextureFiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exclusions",
                columns: new[] { "Id", "Pattern" },
                values: new object[,]
                {
                    { 1, "textures\\\\lod\\\\" },
                    { 2, "textures\\\\interface\\\\" },
                    { 3, "textures\\\\DynDOLOD\\\\" },
                    { 4, "textures\\\\terrain\\\\" },
                    { 5, "textures\\\\.*\\\\chargen\\\\" },
                    { 6, "textures\\\\.*\\\\cubemap.*\\\\" },
                    { 7, "textures\\\\.*\\\\facegen.*\\\\" },
                    { 8, "textures\\\\.*\\\\*hair.*\\\\" },
                    { 9, "textures\\\\.*\\\\*brow.*\\\\" },
                    { 10, "textures\\\\.*\\\\mouth\\\\" },
                    { 11, "textures\\\\.*\\\\*eyes\\\\" },
                    { 12, "textures\\\\.*\\\\*beard.*\\\\" },
                    { 13, "textures\\\\.*\\\\*lashes\\\\" },
                    { 14, "textures\\\\.*\\\\*gash\\\\" },
                    { 15, "textures\\\\.*\\\\*tattoo\\\\" },
                    { 16, "textures\\\\.*\\\\*skin.*\\\\" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exclusions");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "TextureFiles");
        }
    }
}
