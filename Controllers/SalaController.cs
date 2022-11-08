using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/salas")]
[Authorize]
public class SalaController : ControllerBase
{
    [HttpGet]
    public List<Sala> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Salas.ToList();
        }
    }
    [HttpGet("{id}")]
    public Sala Get(int id)
    {
        using (var context = new ITReportContext())
        {
            var sala = context.Salas.Where(s => s.Id == id).FirstOrDefault();
            if (sala == null) throw new Exception("Sala not found");
            return sala;
        }
    }
    [HttpPost("search")]
    public List<SalaSearchResult> Search([FromBody] SearchDto search)
    {
        using (var context = new ITReportContext())
        {
            var salas = context.Salas
                .Include(s => s.Reportes)
                .Include(s => s.Computadoras).ThenInclude(c => c.Reportes)
                .Where(sala => sala.Nombre.ToLower().Contains(search.Value.ToLower()))
                .ToList();

            return salas.Select(sala => new SalaSearchResult()
            {
                Id = sala.Id,
                Nombre = sala.Nombre,
                SolicitudesSala = sala.Reportes.Where(r => r.CategoriaId == (int)Categoria.Solicitud && r.SalaId != null).Count(),
                ReportesSala = sala.Reportes.Where(r => r.CategoriaId == (int)Categoria.Reporte && r.SalaId != null).Count(),
                Computadoras = sala.Computadoras.Count(),
                SolicitudesPC = sala.Computadoras
                    .SelectMany(computadora => computadora.Reportes)
                    .Where(reporte => reporte.CategoriaId == (int)Categoria.Solicitud)
                    .Select(r => r.Id)
                    .Distinct()
                    .Count(),
                ReportesPC = sala.Computadoras
                    .SelectMany(computadora => computadora.Reportes)
                    .Where(reporte => reporte.CategoriaId == (int)Categoria.Reporte)
                    .Select(r => r.Id)
                    .Distinct()
                    .Count(),
            })
            .ToList();
        }
    }
    public class SalaSearchResult
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int SolicitudesSala { get; set; }
        public int ReportesSala { get; set; }
        public int Computadoras { get; set; }
        public int SolicitudesPC { get; set; }
        public int ReportesPC { get; set; }

    }
    [HttpPut("{id}")]
    public Sala Update(int id, [FromBody] SalaCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var sala = context.Salas.Where(s => s.Id == id).FirstOrDefault();
            if (sala == null) throw new Exception("Sala " + id + " not found");

            sala.Edificio = dto.Edificio;
            sala.Nombre = dto.Nombre;

            context.SaveChanges();

            return sala;

        }
    }
    [HttpPost]
    public Sala Create([FromBody] SalaCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var newSala = new Sala();

            newSala.Nombre = dto.Nombre;
            newSala.Edificio = dto.Edificio;

            context.Salas.Add(newSala);
            context.SaveChanges();
            return newSala;
        }
    }
}
public class SalaCreateDto
{
    public string Nombre { get; set; } = null!;
    public string Edificio { get; set; } = null!;
}
public class SearchDto
{
    public string Value { get; set; } = null!;
}
