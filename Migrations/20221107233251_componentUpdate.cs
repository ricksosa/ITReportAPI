using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class componentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_CategoriaComputadora_CategoriaId",
                table: "Componente");

            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Computadoras_ComputadoraId",
                table: "Componente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componente",
                table: "Componente");

            migrationBuilder.RenameTable(
                name: "Componente",
                newName: "Componentes");

            migrationBuilder.RenameIndex(
                name: "IX_Componente_ComputadoraId",
                table: "Componentes",
                newName: "IX_Componentes_ComputadoraId");

            migrationBuilder.RenameIndex(
                name: "IX_Componente_CategoriaId",
                table: "Componentes",
                newName: "IX_Componentes_CategoriaId");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Componentes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_CategoriaComputadora_CategoriaId",
                table: "Componentes",
                column: "CategoriaId",
                principalTable: "CategoriaComputadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Computadoras_ComputadoraId",
                table: "Componentes",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_CategoriaComputadora_CategoriaId",
                table: "Componentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Computadoras_ComputadoraId",
                table: "Componentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Componentes");

            migrationBuilder.RenameTable(
                name: "Componentes",
                newName: "Componente");

            migrationBuilder.RenameIndex(
                name: "IX_Componentes_ComputadoraId",
                table: "Componente",
                newName: "IX_Componente_ComputadoraId");

            migrationBuilder.RenameIndex(
                name: "IX_Componentes_CategoriaId",
                table: "Componente",
                newName: "IX_Componente_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componente",
                table: "Componente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_CategoriaComputadora_CategoriaId",
                table: "Componente",
                column: "CategoriaId",
                principalTable: "CategoriaComputadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Computadoras_ComputadoraId",
                table: "Componente",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id");
        }
    }
}
