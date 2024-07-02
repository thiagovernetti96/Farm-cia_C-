using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmácia_C_.Migrations
{
    public partial class QuantidadeAdicionadaaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Compra");
        }
    }
}
