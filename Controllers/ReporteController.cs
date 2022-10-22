using System.Net;
using ITReportAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/reportes")]
public class ReporteController : ControllerBase
{
    public List<Reporte> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Reportes.ToList();
        }
    }
    [HttpGet("{id}")]
    public Reporte GetById(int id)
    {
        using (var context = new ITReportContext())
        {
            var reporte = context.Reportes.Where(c => c.Id == id).FirstOrDefault();
            if (reporte == null) throw new Exception("Reporte not found");
            return reporte;
        }
    }
    [HttpPost]
    public Reporte Create([FromBody] ReporteCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var newReporte = new Reporte();

            newReporte.ComputadoraId = dto.ComputadoraId;
            newReporte.ComentariosReporte = dto.Comentarios;
            newReporte.FechaDeReporte = DateTime.Now;
            newReporte.CategoriaId = dto.CategoriaId;
            newReporte.EstadoId = (int)EstadoReporte.Pendiente;
            newReporte.TipoDeIncidenteId = dto.TipoDeIncidenteId;

            context.Reportes.Add(newReporte);

            context.SaveChanges();
            return newReporte;
        }
    }
}
public class ReporteCreateDto
{
    public int CategoriaId { get; set; }
    public int ComputadoraId { get; set; }
    public int TipoDeIncidenteId { get; set; }
    public string Comentarios { get; set; } = null!;
}
public enum EstadoReporte
{
    Pendiente = 1,
    Detenido = 2,
    Resuelto = 3

}
