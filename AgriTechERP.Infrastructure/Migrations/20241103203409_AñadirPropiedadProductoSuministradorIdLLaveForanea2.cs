using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    public partial class AñadirPropiedadProductoSuministradorIdLLaveForanea2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
    name: "OrdenCarritoId",
    table: "Inventarios",
    type: "int",
    nullable: true,
    oldClrType: typeof(int),
    oldType: "int");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
