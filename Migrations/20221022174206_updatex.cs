using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class updatex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Computadora_ComputadoraId",
                table: "Componente");

            migrationBuilder.DropForeignKey(
                name: "FK_Computadora_Salas_SalaId",
                table: "Computadora");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Computadora_ComputadoraId",
                table: "Reportes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadora",
                table: "Computadora");

            migrationBuilder.RenameTable(
                name: "Computadora",
                newName: "Computadoras");

            migrationBuilder.RenameIndex(
                name: "IX_Computadora_SalaId",
                table: "Computadoras",
                newName: "IX_Computadoras_SalaId");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Admins",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadoras",
                table: "Computadoras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Computadoras_ComputadoraId",
                table: "Componente",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computadoras_Salas_SalaId",
                table: "Computadoras",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Computadoras_ComputadoraId",
                table: "Componente");

            migrationBuilder.DropForeignKey(
                name: "FK_Computadoras_Salas_SalaId",
                table: "Computadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadoras",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Computadoras",
                newName: "Computadora");

            migrationBuilder.RenameIndex(
                name: "IX_Computadoras_SalaId",
                table: "Computadora",
                newName: "IX_Computadora_SalaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadora",
                table: "Computadora",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Computadora_ComputadoraId",
                table: "Componente",
                column: "ComputadoraId",
                principalTable: "Computadora",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computadora_Salas_SalaId",
                table: "Computadora",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Computadora_ComputadoraId",
                table: "Reportes",
                column: "ComputadoraId",
                principalTable: "Computadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
