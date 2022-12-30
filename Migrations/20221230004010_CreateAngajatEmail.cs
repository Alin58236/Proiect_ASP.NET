using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beerT.Migrations
{
    public partial class CreateAngajatEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Angajat");
        }
    }
}
