using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Data.Migrations
{
    public partial class zzzz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "SeriesEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "SeriesEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link1",
                table: "SeriesEntity");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "SeriesEntity");
        }
    }
}
