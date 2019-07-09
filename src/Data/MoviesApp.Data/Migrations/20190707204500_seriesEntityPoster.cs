using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Data.Migrations
{
    public partial class seriesEntityPoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "SeriesEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "SeriesEntity");
        }
    }
}
