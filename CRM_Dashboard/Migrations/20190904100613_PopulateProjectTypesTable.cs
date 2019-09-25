using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class PopulateProjectTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("ProjectTypes", new[] { "Id", "Name" }, new object[] { 1, "Manufacturing" });
            migrationBuilder.InsertData("ProjectTypes", new[] { "Id", "Name" }, new object[] { 2, "Construction" });
            migrationBuilder.InsertData("ProjectTypes", new[] { "Id", "Name" }, new object[] { 3, "Management" });
            migrationBuilder.InsertData("ProjectTypes", new[] { "Id", "Name" }, new object[] { 4, "Research" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("ProjectTypes", "Id", 1);
            migrationBuilder.DeleteData("ProjectTypes", "Id", 2);
            migrationBuilder.DeleteData("ProjectTypes", "Id", 3);
            migrationBuilder.DeleteData("ProjectTypes", "Id", 4);
        }
    }
}
