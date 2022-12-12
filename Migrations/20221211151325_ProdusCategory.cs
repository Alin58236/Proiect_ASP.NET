﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beerT.Migrations
{
    public partial class ProdusCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdusCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdusCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdusCategory_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdusCategory_CategoryID",
                table: "ProdusCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusCategory_ProdusID",
                table: "ProdusCategory",
                column: "ProdusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdusCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
