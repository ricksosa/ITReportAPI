using System.Net;
using ITReportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/reportes")]
public class ReporteController : ControllerBase
{
    [HttpGet]
    public List<Reporte> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Reportes
            .ToList();
        }
    }
    [HttpPut("{id}")]
    public Reporte Update(int id, [FromBody] ReporteCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var reporte = context.Reportes.Where(r => r.Id == id).FirstOrDefault();
            if (reporte == null) throw new Exception("Report not found");

            reporte.ComputadoraId = dto.ComputadoraId;
            reporte.ComentariosReporte = dto.Comentarios;
            reporte.FechaActualizacion = DateTime.Now;
            reporte.CategoriaId = dto.CategoriaId;
            if (dto.EstadoId.HasValue)
                reporte.EstadoId = dto.EstadoId.Value;
            if (dto.ComentariosAdmin != null)
                reporte.ComentariosAdmin= dto.ComentariosAdmin;

            context.SaveChanges();
            return reporte;
        }
    }
    [HttpPost("filtrar")]
    public List<Reporte> Filtar([FromBody] ReporteFilter filtro)
    {
        using (var context = new ITReportContext())
        {
            var query = context.Reportes.AsQueryable();

            if (filtro?.CategoriaId != null) query = query.Where(r => r.CategoriaId == filtro.CategoriaId);
            if (filtro?.ComputadoraId != null) query = query.Where(r => r.ComputadoraId == filtro.ComputadoraId);
            if (filtro?.EstadoId != null) query = query.Where(r => r.EstadoId == filtro.EstadoId);
            if (filtro?.SalaId != null) query = query.Where(r => r.Computadora.SalaId == filtro.SalaId);
            if (filtro?.TipoDeIncidenteId != null) query = query.Where(r => r.TipoDeIncidenteId == filtro.TipoDeIncidenteId);

            return query.ToList();
        }
    }

    [HttpGet("sala/{id}")]
    public List<Reporte> ReportesPorSala(int id)
    {
        using (var context = new ITReportContext())
        {
            return context.Reportes
            .Where(r => r.Computadora.SalaId == id)
            .ToList();
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
public class ReporteFilter
{
    public int? SalaId { get; set; } = null!;
    public int? EstadoId { get; set; } = null!;
    public int? CategoriaId { get; set; } = null!;
    public int? ComputadoraId { get; set; } = null!;
    public int? TipoDeIncidenteId { get; set; } = null!;
}
public class ReporteCreateDto
{
    public int CategoriaId { get; set; }
    public int ComputadoraId { get; set; }
    public int TipoDeIncidenteId { get; set; }
    public string Comentarios { get; set; } = null!;
    public string ComentariosAdmin { get; set; } = null!;
    public int? EstadoId { get; set; } = null!;
}
public enum EstadoReporte
{
    Pendiente = 1,
    Detenido = 2,
    Resuelto = 3

}
