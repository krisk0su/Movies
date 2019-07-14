using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Data.Migrations
{
    public partial class links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Trailer",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Link1 = table.Column<string>(nullable: true),
                    Link2 = table.Column<string>(nullable: true),
                    Season = table.Column<int>(nullable: false),
                    Episode = table.Column<int>(nullable: false),
                    AnimeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeEntities_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeEntities_AnimeId",
                table: "AnimeEntities",
                column: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeEntities");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropColumn(
                name: "Link1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Trailer",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Movies",
                nullable: false,
                defaultValue: "");
        }
    }
}
