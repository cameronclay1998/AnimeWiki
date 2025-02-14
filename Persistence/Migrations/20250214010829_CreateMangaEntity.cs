using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateMangaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MangaId",
                table: "Photos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Published = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaGenres",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenreId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenres", x => new { x.MangaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MangaGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenres_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MangaId",
                table: "Photos",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenres_GenreId",
                table: "MangaGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Mangas_MangaId",
                table: "Photos",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Mangas_MangaId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "MangaGenres");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropIndex(
                name: "IX_Photos_MangaId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Photos");
        }
    }
}
