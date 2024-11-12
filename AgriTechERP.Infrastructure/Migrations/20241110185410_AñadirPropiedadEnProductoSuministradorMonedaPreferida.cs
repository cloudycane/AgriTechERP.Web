using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    public partial class AñadirPropiedadEnProductoSuministradorMonedaPreferida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonedaPreferida",
                table: "ProductosSuministradores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonedaPreferida",
                table: "ProductosSuministradores");
        }
    }
}
