using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloWorkBank.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeConta = table.Column<string>(type: "NVarchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    IdGerente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeGerente = table.Column<string>(type: "NVarchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.IdGerente);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "NVarchar", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "NVarchar", maxLength: 11, nullable: false),
                    NumeroConta = table.Column<int>(type: "Int", nullable: false),
                    ContaIdConta = table.Column<int>(type: "INTEGER", nullable: false),
                    GerenteIdGerente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdConta = table.Column<int>(type: "INTEGER", nullable: false),
                    IdGerente = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_CLiente_Conta",
                        column: x => x.ContaIdConta,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLiente_Gerente",
                        column: x => x.GerenteIdGerente,
                        principalTable: "Gerente",
                        principalColumn: "IdGerente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContaIdConta",
                table: "Cliente",
                column: "ContaIdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_GerenteIdGerente",
                table: "Cliente",
                column: "GerenteIdGerente");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_NumeroConta",
                table: "Cliente",
                column: "NumeroConta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_IdConta",
                table: "Conta",
                column: "IdConta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gerente_NomeGerente",
                table: "Gerente",
                column: "NomeGerente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Gerente");
        }
    }
}
