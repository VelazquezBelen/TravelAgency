using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExercise.Migrations
{
    public partial class manytomanyrelationbetweencommissionandtravelpackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CommissionTravelPackage",
                columns: table => new
                {
                    CommissionsCommissionId = table.Column<int>(type: "int", nullable: false),
                    TravelPackagesTravelPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionTravelPackage", x => new { x.CommissionsCommissionId, x.TravelPackagesTravelPackageId });
                    table.ForeignKey(
                        name: "FK_CommissionTravelPackage_Commission_CommissionsCommissionId",
                        column: x => x.CommissionsCommissionId,
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionTravelPackage_TravelPackage_TravelPackagesTravelPackageId",
                        column: x => x.TravelPackagesTravelPackageId,
                        principalTable: "TravelPackage",
                        principalColumn: "TravelPackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommissionTravelPackage_TravelPackagesTravelPackageId",
                table: "CommissionTravelPackage",
                column: "TravelPackagesTravelPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionTravelPackage");

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
    }
}
