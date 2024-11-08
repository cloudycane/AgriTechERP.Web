using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    public partial class ProductosProduccionCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduccionModelId",
                table: "ProductosSuministradores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductosProduccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosProduccion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosSuministradores_ProduccionModelId",
                table: "ProductosSuministradores",
                column: "ProduccionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosSuministradores_ProductosProduccion_ProduccionModelId",
                table: "ProductosSuministradores",
                column: "ProduccionModelId",
                principalTable: "ProductosProduccion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosSuministradores_ProductosProduccion_ProduccionModelId",
                table: "ProductosSuministradores");

            migrationBuilder.DropTable(
                name: "ProductosProduccion");

            migrationBuilder.DropIndex(
                name: "IX_ProductosSuministradores_ProduccionModelId",
                table: "ProductosSuministradores");

            migrationBuilder.DropColumn(
                name: "ProduccionModelId",
                table: "ProductosSuministradores");
        }
    }
}
