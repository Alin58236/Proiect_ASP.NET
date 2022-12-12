using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beerT.Migrations
{
    public partial class Angajati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistribuitorID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distribuitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistribuitorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuitor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_DistribuitorID",
                table: "Produs",
                column: "DistribuitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Distribuitor_DistribuitorID",
                table: "Produs",
                column: "DistribuitorID",
                principalTable: "Distribuitor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Distribuitor_DistribuitorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Distribuitor");

            migrationBuilder.DropIndex(
                name: "IX_Produs_DistribuitorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "DistribuitorID",
                table: "Produs");
        }
    }
}
