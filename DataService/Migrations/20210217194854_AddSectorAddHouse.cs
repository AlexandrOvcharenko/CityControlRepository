using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class AddSectorAddHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Sectors_SectorId1",
                table: "House");

            migrationBuilder.DropPrimaryKey(
                name: "PK_House",
                table: "House");

            migrationBuilder.RenameTable(
                name: "House",
                newName: "Houses");

            migrationBuilder.RenameIndex(
                name: "IX_House_SectorId1",
                table: "Houses",
                newName: "IX_Houses_SectorId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Sectors_SectorId1",
                table: "Houses",
                column: "SectorId1",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Sectors_SectorId1",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.RenameTable(
                name: "Houses",
                newName: "House");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_SectorId1",
                table: "House",
                newName: "IX_House_SectorId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_House",
                table: "House",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Sectors_SectorId1",
                table: "House",
                column: "SectorId1",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
