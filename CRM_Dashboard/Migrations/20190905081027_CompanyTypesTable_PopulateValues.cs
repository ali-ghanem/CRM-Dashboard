using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class CompanyTypesTable_PopulateValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("CompanyTypes", new[] { "Id", "Name" }, new object[] { 1, "Public" });
            migrationBuilder.InsertData("CompanyTypes", new[] { "Id", "Name" }, new object[] { 2, "Private" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("CompanyTypes", "Id", 1);
            migrationBuilder.DeleteData("CompanyTypes", "Id", 2);

        }
    }
}
