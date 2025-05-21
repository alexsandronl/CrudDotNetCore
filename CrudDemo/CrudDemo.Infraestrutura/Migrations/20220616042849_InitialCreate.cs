using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDemo.Infraestrutura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeCompleto = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TipoDeDocumento = table.Column<int>(type: "integer", nullable: false),
                    IndicadorClienteAtivo = table.Column<bool>(type: "boolean", nullable: false),
                    Logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    DataDoCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
