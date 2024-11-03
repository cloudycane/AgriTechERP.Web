using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    public partial class AñadirPropiedadProductoSuministradorIdLLaveForanea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop existing foreign keys if needed
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_OrdenCarritos_OrdenCarritoId",
                table: "Inventarios");

            // Alter the OrdenCarritoId column to be nullable if using SET NULL
            migrationBuilder.AlterColumn<int>(
                name: "OrdenCarritoId",
                table: "Inventarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Add ProductoSuministradorId column
            migrationBuilder.AddColumn<int>(
                name: "ProductoSuministradorId",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Create index on ProductoSuministradorId
            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ProductoSuministradorId",
                table: "Inventarios",
                column: "ProductoSuministradorId");

            // Re-add the foreign keys with the desired delete behavior
            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_OrdenCarritos_OrdenCarritoId",
                table: "Inventarios",
                column: "OrdenCarritoId",
                principalTable: "OrdenCarritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            // Set ProductoSuministradorId to NO ACTION to avoid cascading issues
            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ProductosSuministradores_ProductoSuministradorId",
                table: "Inventarios",
                column: "ProductoSuministradorId",
                principalTable: "ProductosSuministradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_OrdenCarritos_OrdenCarritoId",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ProductosSuministradores_ProductoSuministradorId",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_ProductoSuministradorId",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "ProductoSuministradorId",
                table: "Inventarios");

            // Revert OrdenCarritoId column to be non-nullable
            migrationBuilder.AlterColumn<int>(
                name: "OrdenCarritoId",
                table: "Inventarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_OrdenCarritos_OrdenCarritoId",
                table: "Inventarios",
                column: "OrdenCarritoId",
                principalTable: "OrdenCarritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }

}