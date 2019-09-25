using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class GendersTable_Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Genders_GenderId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Genders_GenderId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Visits_GenderId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GenderId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "DealPayments");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Visits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Visits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Visits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "DealPayments",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Female" });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_GenderId",
                table: "Visits",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GenderId",
                table: "Customers",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Genders_GenderId",
                table: "Customers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Genders_GenderId",
                table: "Visits",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
