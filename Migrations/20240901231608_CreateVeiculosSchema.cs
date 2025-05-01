using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrudVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class CreateVeiculosSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    IdCor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.IdCor);
                });

            migrationBuilder.CreateTable(
                name: "MarcasVeiculo",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeMarca = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasVeiculo", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    AnoFabricacaoModelo = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Chassis = table.Column<string>(type: "text", nullable: false),
                    RenavamVeiculo = table.Column<string>(type: "text", nullable: false),
                    FkIdMarca = table.Column<int>(type: "integer", nullable: false),
                    FkIdCor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.IdVeiculo);
                    table.ForeignKey(
                        name: "FK_Veiculos_Cores_FkIdCor",
                        column: x => x.FkIdCor,
                        principalTable: "Cores",
                        principalColumn: "IdCor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_MarcasVeiculo_FkIdMarca",
                        column: x => x.FkIdMarca,
                        principalTable: "MarcasVeiculo",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FkIdCor",
                table: "Veiculos",
                column: "FkIdCor");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FkIdMarca",
                table: "Veiculos",
                column: "FkIdMarca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "MarcasVeiculo");
        }
    }
}
