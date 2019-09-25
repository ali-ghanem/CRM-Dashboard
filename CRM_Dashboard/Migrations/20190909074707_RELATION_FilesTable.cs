using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Dashboard.Migrations
{
    public partial class RELATION_FilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DealId",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DealPaymentId",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_DealId",
                table: "Files",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DealPaymentId",
                table: "Files",
                column: "DealPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProjectId",
                table: "Files",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_VisitId",
                table: "Files",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Deals_DealId",
                table: "Files",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_DealPayments_DealPaymentId",
                table: "Files",
                column: "DealPaymentId",
                principalTable: "DealPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Visits_VisitId",
                table: "Files",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Deals_DealId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_DealPayments_DealPaymentId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Visits_VisitId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DealId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DealPaymentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProjectId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_VisitId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DealId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DealPaymentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Files");
        }
    }
}
