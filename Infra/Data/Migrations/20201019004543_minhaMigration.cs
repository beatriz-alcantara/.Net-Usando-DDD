using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class minhaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PetshopDB");

            migrationBuilder.CreateTable(
                name: "Loja",
                schema: "PetshopDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "PetshopDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    LojaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Loja_LojaId",
                        column: x => x.LojaId,
                        principalSchema: "PetshopDB",
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                schema: "PetshopDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Raca = table.Column<string>(maxLength: 20, nullable: false),
                    Especie = table.Column<string>(maxLength: 30, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "PetshopDB",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_LojaId",
                schema: "PetshopDB",
                table: "Cliente",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ClienteId",
                schema: "PetshopDB",
                table: "Pet",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet",
                schema: "PetshopDB");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "PetshopDB");

            migrationBuilder.DropTable(
                name: "Loja",
                schema: "PetshopDB");
        }
    }
}
