using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class AddFilesColumnToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "Customers",
                newName: "Files");

            migrationBuilder.AddColumn<byte[]>(
                name: "Files",
                table: "Visits",
                nullable: true);

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
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
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
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Files",
                table: "Customers",
                newName: "File");
        }
    }
}
