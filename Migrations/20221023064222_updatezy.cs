using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class updatezy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadosReporte",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 4, "Nuevo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadosReporte",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
