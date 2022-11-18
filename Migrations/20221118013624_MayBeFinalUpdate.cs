using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class MayBeFinalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadosReporte",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 5, "Atendido" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadosReporte",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
