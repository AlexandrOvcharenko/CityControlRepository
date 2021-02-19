using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class AddSectorNameToHouse1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectorName",
                table: "Houses",
                newName: "SectorSukaName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectorSukaName",
                table: "Houses",
                newName: "SectorName");
        }
    }
}
