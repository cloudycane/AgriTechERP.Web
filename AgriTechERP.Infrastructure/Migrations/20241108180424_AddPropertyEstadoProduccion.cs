using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    public partial class AddPropertyEstadoProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoProductoProduccion",
                table: "ProductosProduccion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoProductoProduccion",
                table: "ProductosProduccion");
        }
    }
}
