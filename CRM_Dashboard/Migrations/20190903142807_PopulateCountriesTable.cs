using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class PopulateCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Countries", new[] { "Id", "Name" }, new object[] { 1, "Syria" });
            migrationBuilder.InsertData("Countries", new[] { "Id", "Name" }, new object[] { 2, "Turkey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Countries",
            keyColumn: "Id",
            keyValue: 1);

            migrationBuilder.DeleteData(
            table: "Countries",
            keyColumn: "Id",
            keyValue: 2);
        }
    }
}
