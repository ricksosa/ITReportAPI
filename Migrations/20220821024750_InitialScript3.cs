using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class InitialScript3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriaReporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaReporte", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoReporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReporte", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeIncidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeIncidente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaDeReporte = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ComentariosReporte = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComentariosAdmin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    IdComputadora = table.Column<int>(type: "int", nullable: false),
                    ComputadoraId = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IncidenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportes_CategoriaReporte_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaReporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_Computadora_ComputadoraId",
                        column: x => x.ComputadoraId,
                        principalTable: "Computadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_EstadoReporte_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoReporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_TipoDeIncidente_IncidenteId",
                        column: x => x.IncidenteId,
                        principalTable: "TipoDeIncidente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_CategoriaId",
                table: "Reportes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_ComputadoraId",
                table: "Reportes",
                column: "ComputadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_EstadoId",
                table: "Reportes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_IncidenteId",
                table: "Reportes",
                column: "IncidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_SalaId",
                table: "Reportes",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "CategoriaReporte");

            migrationBuilder.DropTable(
                name: "EstadoReporte");

            migrationBuilder.DropTable(
                name: "TipoDeIncidente");
        }
    }
}
