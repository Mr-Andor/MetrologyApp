using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetrologyApp.DataAccess.Migrations
{
    public partial class updateResultModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Z = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NominalPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Z = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominalPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avgPointX = table.Column<double>(type: "float", nullable: false),
                    avgPointY = table.Column<double>(type: "float", nullable: false),
                    avgPointZ = table.Column<double>(type: "float", nullable: false),
                    deviation = table.Column<double>(type: "float", nullable: false),
                    NominalPointId = table.Column<int>(type: "int", nullable: false),
                    ActualPointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualPoints");

            migrationBuilder.DropTable(
                name: "NominalPoints");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
