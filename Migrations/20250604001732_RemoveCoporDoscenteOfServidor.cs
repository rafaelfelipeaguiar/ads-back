using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoporDoscenteOfServidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CorpoDocente_ServidorId",
                table: "CorpoDocente");

            migrationBuilder.CreateIndex(
                name: "IX_CorpoDocente_ServidorId",
                table: "CorpoDocente",
                column: "ServidorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CorpoDocente_ServidorId",
                table: "CorpoDocente");

            migrationBuilder.CreateIndex(
                name: "IX_CorpoDocente_ServidorId",
                table: "CorpoDocente",
                column: "ServidorId",
                unique: true);
        }
    }
}
