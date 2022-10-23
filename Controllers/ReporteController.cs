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

            if (dto.ComputadoraId.HasValue)
                reporte.ComputadoraId = dto.ComputadoraId.Value;
            if (dto.Comentarios != null)
                reporte.ComentariosReporte = dto.Comentarios;
            if (dto.CategoriaId.HasValue)
                reporte.CategoriaId = dto.CategoriaId.Value;
            if (dto.EstadoId.HasValue)
                reporte.EstadoId = dto.EstadoId.Value;
            if (dto.ComentariosAdmin != null)
                reporte.ComentariosAdmin = dto.ComentariosAdmin;

            reporte.FechaActualizacion = DateTime.Now;

            context.SaveChanges();
            return reporte;
        }
    }
    [HttpPost("filtrar")]
    public List<Reporte> Filtar([FromBody] ReporteFilter filtro)
    {
        using (var context = new ITReportContext())
        {
            var query = context.Reportes
                .AsQueryable();

            if (filtro?.CategoriaId != null) query = query.Where(r => r.CategoriaId == filtro.CategoriaId);
            if (filtro?.ComputadoraId != null) query = query.Where(r => r.ComputadoraId == filtro.ComputadoraId);
            if (filtro?.EstadoId != null) query = query.Where(r => r.EstadoId == filtro.EstadoId);
            if (filtro?.SalaId != null) query = query.Where(r => r.SalaId == filtro.SalaId);
            if (filtro?.TipoDeIncidenteId != null) query = query.Where(r => r.TipoDeIncidenteId == filtro.TipoDeIncidenteId);
            if (filtro?.IgnorarEstadoId != null) query.Where(r => r.EstadoId != filtro.IgnorarEstadoId);

            return query
                .Include(r => r.Categoria)
                .Include(r => r.Computadora)
                .Include(r => r.Sala)
                .Include(r => r.Computadora.Sala)
                .Include(r => r.Estado)
                .Include(r => r.Incidente)
                .ToList();
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
    public IActionResult Create([FromBody] ReporteCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var newReporte = new Reporte();

            if (dto.SalaId != null) newReporte.SalaId = dto.SalaId;
            else if (dto.ComputadoraId != null) newReporte.ComputadoraId = dto.ComputadoraId;
            else return Ok(newReporte);

            var isReporteDuplicado = context.Reportes.Where(reporte =>
                (
                    (newReporte.SalaId != null && reporte.SalaId == newReporte.SalaId) ||
                    (newReporte.ComputadoraId != null && reporte.ComputadoraId == newReporte.ComputadoraId)
                ) &&
                reporte.CategoriaId == (int)Categoria.Reporte &&
                reporte.TipoDeIncidenteId == dto.TipoDeIncidenteId
            ).Count() > 0;

            if (isReporteDuplicado) return Ok(newReporte);

            if (dto.Comentarios != null)
                newReporte.ComentariosReporte = dto.Comentarios;
            newReporte.FechaDeReporte = DateTime.Now;

            if (!dto.CategoriaId.HasValue) return BadRequest(new { Message = "No se seleccionó una categoría" });
            newReporte.CategoriaId = dto.CategoriaId.Value;
            if (!dto.TipoDeIncidenteId.HasValue) return BadRequest(new { Message = "No se seleccionó una tipo de incidente" });
            newReporte.TipoDeIncidenteId = dto.TipoDeIncidenteId.Value;

            newReporte.EstadoId = (int)EstadoReporte.Nuevo;

            context.Reportes.Add(newReporte);

            context.SaveChanges();
            return Ok(newReporte);
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
    public int? IgnorarEstadoId { get; set; } = null!;
}
public class ReporteCreateDto
{
    public int? CategoriaId { get; set; }
    public int? ComputadoraId { get; set; }
    public int? SalaId { get; set; }
    public int? TipoDeIncidenteId { get; set; }
    public string? Comentarios { get; set; } = null!;
    public string? ComentariosAdmin { get; set; } = null!;
    public int? EstadoId { get; set; } = null!;
}
public enum EstadoReporte
{
    Pendiente = 1,
    Detenido = 2,
    Resuelto = 3,
    Nuevo = 4

}
