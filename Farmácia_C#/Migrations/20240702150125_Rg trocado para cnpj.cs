using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmácia_C_.Migrations
{
    public partial class Rgtrocadoparacnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Fornecedor",
                newName: "CNPJ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Fornecedor",
                newName: "RG");
        }
    }
}
