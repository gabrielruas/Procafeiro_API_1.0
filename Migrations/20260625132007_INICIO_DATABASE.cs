using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace procafeiro.Migrations
{
    public partial class INICIO_DATABASE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Panhas",
                columns: table => new
                {
                    IdPanha = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeColobarador = table.Column<string>(type: "TEXT", nullable: true),
                    Nmedidas = table.Column<int>(type: "INTEGER", nullable: false),
                    Nlitros = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panhas", x => x.IdPanha);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panhas");
        }
    }
}
