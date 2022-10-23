using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class updatexl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoriaComputadora",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Software" });

            migrationBuilder.InsertData(
                table: "CategoriaComputadora",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Hardware" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriaComputadora",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriaComputadora",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
