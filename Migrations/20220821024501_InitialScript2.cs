using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class InitialScript2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Computadora",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Computadora");
        }
    }
}
