using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExercise.Migrations
{
    public partial class categorycanbenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "TravelPackageId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product",
                column: "TravelPackageId",
                principalTable: "TravelPackage",
                principalColumn: "TravelPackageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "TravelPackageId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TravelPackage_TravelPackageId",
                table: "Product",
                column: "TravelPackageId",
                principalTable: "TravelPackage",
                principalColumn: "TravelPackageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
