using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExercise.Migrations
{
    public partial class Relationmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_TravelPackageId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TravelPackageId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductTravelPackage",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    TravelPackagesTravelPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTravelPackage", x => new { x.ProductsProductId, x.TravelPackagesTravelPackageId });
                    table.ForeignKey(
                        name: "FK_ProductTravelPackage_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTravelPackage_TravelPackage_TravelPackagesTravelPackageId",
                        column: x => x.TravelPackagesTravelPackageId,
                        principalTable: "TravelPackage",
                        principalColumn: "TravelPackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTravelPackage_TravelPackagesTravelPackageId",
                table: "ProductTravelPackage",
                column: "TravelPackagesTravelPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTravelPackage");

            migrationBuilder.AddColumn<int>(
                name: "TravelPackageId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_TravelPackageId",
                table: "Product",
                column: "TravelPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product",
                column: "TravelPackageId",
                principalTable: "TravelPackage",
                principalColumn: "TravelPackageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
