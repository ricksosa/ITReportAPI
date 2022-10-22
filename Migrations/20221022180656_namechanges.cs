using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class namechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Salas_SalaId",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "IdComputadora",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Computadoras");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Reportes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Salas_SalaId",
                table: "Reportes",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Salas_SalaId",
                table: "Reportes");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Reportes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdComputadora",
                table: "Reportes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Reportes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Computadoras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Salas_SalaId",
                table: "Reportes",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
