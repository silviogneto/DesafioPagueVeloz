using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPagueVeloz.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    CNPJ = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Documento = table.Column<string>(nullable: false),
                    RG = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    EmpresaCNPJ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Empresas_EmpresaCNPJ",
                        column: x => x.EmpresaCNPJ,
                        principalTable: "Empresas",
                        principalColumn: "CNPJ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroTelefone = table.Column<string>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_EmpresaCNPJ",
                table: "Fornecedores",
                column: "EmpresaCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FornecedorId",
                table: "Telefones",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
