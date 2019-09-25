using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class Relation_Companies_Files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CompanyId",
                table: "Files",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Companies_CompanyId",
                table: "Files",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Companies_CompanyId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CompanyId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Files");
        }
    }
}
