using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Views_Modulos_ModuleId",
                table: "Views");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Views",
                newName: "ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Views_ModuleId",
                table: "Views",
                newName: "IX_Views_ModuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Modulos_ModuloId",
                table: "Views",
                column: "ModuloId",
                principalTable: "Modulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Views_Modulos_ModuloId",
                table: "Views");

            migrationBuilder.RenameColumn(
                name: "ModuloId",
                table: "Views",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Views_ModuloId",
                table: "Views",
                newName: "IX_Views_ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Modulos_ModuleId",
                table: "Views",
                column: "ModuleId",
                principalTable: "Modulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
