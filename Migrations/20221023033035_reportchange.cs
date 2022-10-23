using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class reportchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes");

            migrationBuilder.AlterColumn<int>(
                name: "ComputadoraId",
                table: "Reportes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes");

            migrationBuilder.AlterColumn<int>(
                name: "ComputadoraId",
                table: "Reportes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Computadoras_ComputadoraId",
                table: "Reportes",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
