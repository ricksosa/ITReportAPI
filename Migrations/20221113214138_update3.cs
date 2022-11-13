using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Computadoras_ComputadoraId",
                table: "Componentes");

            migrationBuilder.DropIndex(
                name: "IX_Componentes_ComputadoraId",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "ComputadoraId",
                table: "Componentes");

            migrationBuilder.CreateTable(
                name: "ComponenteComputadora",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "int", nullable: false),
                    ComputadorasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteComputadora", x => new { x.ComponentsId, x.ComputadorasId });
                    table.ForeignKey(
                        name: "FK_ComponenteComputadora_Componentes_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteComputadora_Computadoras_ComputadorasId",
                        column: x => x.ComputadorasId,
                        principalTable: "Computadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteComputadora_ComputadorasId",
                table: "ComponenteComputadora",
                column: "ComputadorasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteComputadora");

            migrationBuilder.AddColumn<int>(
                name: "ComputadoraId",
                table: "Componentes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ComputadoraId",
                table: "Componentes",
                column: "ComputadoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Computadoras_ComputadoraId",
                table: "Componentes",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id");
        }
    }
}
