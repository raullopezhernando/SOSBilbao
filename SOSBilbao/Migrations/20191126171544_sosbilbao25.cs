using Microsoft.EntityFrameworkCore.Migrations;

namespace SOSBilbao.Migrations
{
    public partial class sosbilbao25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "zonaId",
                table: "UsuarioParadasTaxi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioParadasTaxi_zonaId",
                table: "UsuarioParadasTaxi",
                column: "zonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioParadasTaxi_Zona_zonaId",
                table: "UsuarioParadasTaxi",
                column: "zonaId",
                principalTable: "Zona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioParadasTaxi_Zona_zonaId",
                table: "UsuarioParadasTaxi");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioParadasTaxi_zonaId",
                table: "UsuarioParadasTaxi");

            migrationBuilder.DropColumn(
                name: "zonaId",
                table: "UsuarioParadasTaxi");
        }
    }
}
