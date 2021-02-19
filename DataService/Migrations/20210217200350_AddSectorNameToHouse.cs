using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class AddSectorNameToHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectorName",
                table: "Houses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectorName",
                table: "Houses");
        }
    }
}
