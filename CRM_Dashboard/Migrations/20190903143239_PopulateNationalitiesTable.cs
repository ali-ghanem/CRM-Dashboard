using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class PopulateNationalitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Nationalities", new[] { "Id", "Name" }, new object[] { 1, "Syrian" });
            migrationBuilder.InsertData("Nationalities", new[] { "Id", "Name" }, new object[] { 2, "Turkish" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Nationalities",
            keyColumn: "Id",
            keyValue: 1);

            migrationBuilder.DeleteData(
            table: "Nationalities",
            keyColumn: "Id",
            keyValue: 2);
        }
    }
}
