using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beerT.Migrations
{
    public partial class clientfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Comanda");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Client",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Client",
                newName: "Prenume");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Client",
                newName: "Nume");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Client",
                newName: "Adresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Client",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Prenume",
                table: "Client",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Nume",
                table: "Client",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Adresa",
                table: "Client",
                newName: "Adress");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Comanda",
                type: "int",
                nullable: true);
        }
    }
}
