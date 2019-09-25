using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class ProjectsTypeTable_EditPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsTypes",
                table: "ProjectsTypes");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProjectsTypes",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsTypes",
                table: "ProjectsTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsTypes_ProjectId",
                table: "ProjectsTypes",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsTypes",
                table: "ProjectsTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsTypes_ProjectId",
                table: "ProjectsTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectsTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsTypes",
                table: "ProjectsTypes",
                columns: new[] { "ProjectId", "ProjectTypeId" });
        }
    }
}
