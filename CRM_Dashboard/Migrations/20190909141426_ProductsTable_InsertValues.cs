using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class ProductsTable_InsertValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Products", new string[] { "Id", "Name" }, new object[] { 1, "Product 1" });
            migrationBuilder.InsertData("Products", new string[] { "Id", "Name" }, new object[] { 2, "Product 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Products", "Id", 1);
            migrationBuilder.DeleteData("Products", "Id", 2);

        }
    }
}
