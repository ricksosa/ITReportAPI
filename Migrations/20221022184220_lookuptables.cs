using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITReportAPI.Migrations
{
    public partial class lookuptables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_CategoriaReporte_CategoriaId",
                table: "Reportes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_EstadoReporte_EstadoId",
                table: "Reportes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_TipoDeIncidente_IncidenteId",
                table: "Reportes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoDeIncidente",
                table: "TipoDeIncidente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoReporte",
                table: "EstadoReporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaReporte",
                table: "CategoriaReporte");

            migrationBuilder.RenameTable(
                name: "TipoDeIncidente",
                newName: "TiposDeIncidente");

            migrationBuilder.RenameTable(
                name: "EstadoReporte",
                newName: "EstadosReporte");

            migrationBuilder.RenameTable(
                name: "CategoriaReporte",
                newName: "CategoriasReporte");

            migrationBuilder.RenameColumn(
                name: "IncidenteId",
                table: "Reportes",
                newName: "TipoDeIncidenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Reportes_IncidenteId",
                table: "Reportes",
                newName: "IX_Reportes_TipoDeIncidenteId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaReporteId",
                table: "TiposDeIncidente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDeIncidente",
                table: "TiposDeIncidente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadosReporte",
                table: "EstadosReporte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasReporte",
                table: "CategoriasReporte",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CategoriasReporte",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Reporte" },
                    { 2, "Solicitud" }
                });

            migrationBuilder.InsertData(
                table: "EstadosReporte",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Detenido" },
                    { 3, "Resuelto" }
                });

            migrationBuilder.InsertData(
                table: "TiposDeIncidente",
                columns: new[] { "Id", "CategoriaReporteId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Sin Internet" },
                    { 2, 1, "No prende" },
                    { 3, 2, "Instalar" },
                    { 4, 2, "Optimizar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeIncidente_CategoriaReporteId",
                table: "TiposDeIncidente",
                column: "CategoriaReporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_CategoriasReporte_CategoriaId",
                table: "Reportes",
                column: "CategoriaId",
                principalTable: "CategoriasReporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_EstadosReporte_EstadoId",
                table: "Reportes",
                column: "EstadoId",
                principalTable: "EstadosReporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_TiposDeIncidente_TipoDeIncidenteId",
                table: "Reportes",
                column: "TipoDeIncidenteId",
                principalTable: "TiposDeIncidente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiposDeIncidente_CategoriasReporte_CategoriaReporteId",
                table: "TiposDeIncidente",
                column: "CategoriaReporteId",
                principalTable: "CategoriasReporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_CategoriasReporte_CategoriaId",
                table: "Reportes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_EstadosReporte_EstadoId",
                table: "Reportes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_TiposDeIncidente_TipoDeIncidenteId",
                table: "Reportes");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposDeIncidente_CategoriasReporte_CategoriaReporteId",
                table: "TiposDeIncidente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDeIncidente",
                table: "TiposDeIncidente");

            migrationBuilder.DropIndex(
                name: "IX_TiposDeIncidente_CategoriaReporteId",
                table: "TiposDeIncidente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadosReporte",
                table: "EstadosReporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasReporte",
                table: "CategoriasReporte");

            migrationBuilder.DeleteData(
                table: "EstadosReporte",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadosReporte",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadosReporte",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposDeIncidente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposDeIncidente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposDeIncidente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposDeIncidente",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoriasReporte",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriasReporte",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CategoriaReporteId",
                table: "TiposDeIncidente");

            migrationBuilder.RenameTable(
                name: "TiposDeIncidente",
                newName: "TipoDeIncidente");

            migrationBuilder.RenameTable(
                name: "EstadosReporte",
                newName: "EstadoReporte");

            migrationBuilder.RenameTable(
                name: "CategoriasReporte",
                newName: "CategoriaReporte");

            migrationBuilder.RenameColumn(
                name: "TipoDeIncidenteId",
                table: "Reportes",
                newName: "IncidenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Reportes_TipoDeIncidenteId",
                table: "Reportes",
                newName: "IX_Reportes_IncidenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoDeIncidente",
                table: "TipoDeIncidente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoReporte",
                table: "EstadoReporte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaReporte",
                table: "CategoriaReporte",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_CategoriaReporte_CategoriaId",
                table: "Reportes",
                column: "CategoriaId",
                principalTable: "CategoriaReporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_EstadoReporte_EstadoId",
                table: "Reportes",
                column: "EstadoId",
                principalTable: "EstadoReporte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_TipoDeIncidente_IncidenteId",
                table: "Reportes",
                column: "IncidenteId",
                principalTable: "TipoDeIncidente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
