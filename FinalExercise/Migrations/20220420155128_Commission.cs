using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExercise.Migrations
{
    public partial class Commission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commission",
                columns: table => new
                {
                    CommissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientTypeId = table.Column<int>(type: "int", nullable: false),
                    PassengersAmmount = table.Column<int>(type: "int", nullable: false),
                    TripDuration = table.Column<int>(type: "int", nullable: false),
                    TravelPackageIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionResult = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.CommissionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commission");
        }
    }
}
