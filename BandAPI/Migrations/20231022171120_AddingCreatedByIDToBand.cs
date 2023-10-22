using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BandAPI.Migrations
{
    public partial class AddingCreatedByIDToBand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Bands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bands_CreatedById",
                table: "Bands",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Bands_Users_CreatedById",
                table: "Bands",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bands_Users_CreatedById",
                table: "Bands");

            migrationBuilder.DropIndex(
                name: "IX_Bands_CreatedById",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Bands");
        }
    }
}
