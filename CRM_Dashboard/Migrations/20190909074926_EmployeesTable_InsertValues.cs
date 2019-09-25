using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class EmployeesTable_InsertValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Employees",
                new string[] { "Id", "FirstName", "LastName", "JobTitleId", "Gender", "BirthDate", "CountryId", "CityId", "Nationality1Id", "Nationality2Id" },
                new object[] { 1, "employee1", "EMPLOYEE1", 1, 0, "01-01-1990", 1, 1, 1, 1 });
            migrationBuilder.InsertData("Employees",
                new string[] { "Id", "FirstName", "LastName", "JobTitleId", "Gender", "BirthDate", "CountryId", "CityId", "Nationality1Id", "Nationality2Id" },
                new object[] { 2, "employee2", "EMPLOYEE2", 1, 0, "01-01-1990", 1, 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Employees", "Id", 1);
            migrationBuilder.DeleteData("Employees", "Id", 2);
        }
    }
}
