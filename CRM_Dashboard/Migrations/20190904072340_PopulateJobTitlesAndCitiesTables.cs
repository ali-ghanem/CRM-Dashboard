using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class PopulateJobTitlesAndCitiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("JobTitles", new[] { "Id", "Name" }, new object[] { 1, "Computer Engineer" });
            migrationBuilder.InsertData("JobTitles", new[] { "Id", "Name" }, new object[] { 2, "Mechanical Engineer" });
            migrationBuilder.InsertData("Cities", new[] { "Id", "Name" }, new object[] { 1, "Damascus" });
            migrationBuilder.InsertData("Cities", new[] { "Id", "Name" }, new object[] { 2, "Istanbul" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("JobTitles", "Id", 1);
            migrationBuilder.DeleteData("JobTitles", "Id", 2);
            migrationBuilder.DeleteData("Cities", "Id", 1);
            migrationBuilder.DeleteData("Cities", "Id", 2);

        }
    }
}
