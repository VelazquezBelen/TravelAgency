using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExercise.Migrations
{
    public partial class updatemodelcommission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelPackageIds",
                table: "Commission");

            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "TravelPackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackage_CommissionId",
                table: "TravelPackage",
                column: "CommissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackage_Commission_CommissionId",
                table: "TravelPackage",
                column: "CommissionId",
                principalTable: "Commission",
                principalColumn: "CommissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackage_Commission_CommissionId",
                table: "TravelPackage");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackage_CommissionId",
                table: "TravelPackage");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "TravelPackage");

            migrationBuilder.AddColumn<string>(
                name: "TravelPackageIds",
                table: "Commission",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
