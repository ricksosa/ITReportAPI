using System.Net;
using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/computadoras")]
[Authorize]
public class ComputadoraController : ControllerBase
{
    [HttpGet]
    public List<Computadora> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Computadoras
            .Include(c => c.Components)
            .ToList();
        }
    }
    [HttpGet("sala/{id}")]
    [AllowAnonymous]
    public List<Computadora> GetBySala(int id)
    {
        using (var context = new ITReportContext())
        {
            return context.Computadoras
            .Include(c => c.Components)
            .Include(c => c.Reportes.Where(r => r.EstadoId != (int)EstadoReporte.Nuevo && r.EstadoId != (int)EstadoReporte.Resuelto))
            .Where(c => c.SalaId == id)
            .ToList();
        }
    }
    [HttpGet("{id}")]
    public Computadora GetById(int id)
    {
        using (var context = new ITReportContext())
        {
            var computadora = context.Computadoras.Where(c => c.Id == id).FirstOrDefault();
            if (computadora == null) throw new Exception("Computadora not found");
            return computadora;
        }
    }
    [HttpPut("{id}")]
    public Computadora Update(int id, [FromBody] ComputadoraCreateDTO dto)
    {
        using (var context = new ITReportContext())
        {
            var computadora = context.Computadoras.Where(c => c.Id == id).FirstOrDefault();
            if (computadora == null) throw new Exception("Computadora " + id + " not found");

            computadora.Gabinete = dto.Gabinete;
            computadora.SalaId = dto.SalaId;

            context.SaveChanges();
            return computadora;

        }
    }
    [AllowAnonymous]
    [HttpPost("search")]
    public List<ComputadorasSearchResult> Search(SearchDto search)
    {
        using (var context = new ITReportContext())
        {
            return context.Computadoras.Where(c => c.Gabinete.ToLower().Contains(search.Value.ToLower()))
            .Include(c => c.Components)
            .Include(c => c.Reportes)
            .Select(computadora => new ComputadorasSearchResult()
            {
                Id = computadora.Id,
                Gabinete = computadora.Gabinete,
                Solicitudes = computadora.Reportes.Where(r => r.CategoriaId == (int)Categoria.Solicitud && r.EstadoId != (int)EstadoReporte.Resuelto && r.EstadoId != (int)EstadoReporte.Nuevo).Count(),
                Reportes = computadora.Reportes.Where(r => r.CategoriaId == (int)Categoria.Reporte && r.EstadoId != (int)EstadoReporte.Resuelto && r.EstadoId != (int)EstadoReporte.Nuevo).Count(),
                Componentes = computadora.Components.Count,
                Software = computadora.Components.Where(c => c.CategoriaId == (int)CategoriaComponent.Software).Count(),
                Hardware = computadora.Components.Where(c => c.CategoriaId == (int)CategoriaComponent.Hardware).Count(),
            }).ToList();
        }
    }
    public class ComputadorasSearchResult
    {
        public int Id { get; set; }
        public string Gabinete { get; set; } = null!;
        public int Solicitudes { get; set; }
        public int Reportes { get; set; }
        public int Componentes { get; set; }
        public int Software { get; set; }
        public int Hardware { get; set; }
    }
    [HttpPost("v2")]
    public ActionResult CreateV2([FromBody] ComputadoraCreateDTOv2 dto)
    {
        using (var context = new ITReportContext())
        {
            var computadora = new Computadora();

            computadora.Gabinete = dto.Gabinete;
            computadora.SalaId = dto.SalaId;
            computadora.Components = new List<Componente>();
            if (context.Computadoras.Any(c => c.Gabinete == dto.Gabinete))
            {
                return BadRequest(new { Message = "Ya existe una computadora con ese número de Gabinete" });
            }

            context.Computadoras.Add(computadora);
            context.SaveChanges();

            if (dto.ComponentesSoftware != null)
                dto.ComponentesSoftware.ForEach(Id => computadora.Components.Add(context.Componentes.Where(c => c.Id == Id).First()));

            if (dto.ComponentsHardware != null)
                dto.ComponentsHardware.ForEach(Id => computadora.Components.Add(context.Componentes.Where(c => c.Id == Id).First()));

            if (dto.ComponentsHardware != null || dto.ComponentesSoftware != null)
                context.SaveChanges();

            return Ok(computadora);
        }
    }
    [HttpPut("v2/{id}")]
    public IActionResult UpdateV2(int id, [FromBody] ComputadoraCreateDTOv2 dto)
    {
        using (var context = new ITReportContext())
        {
            var computadora = context
                .Computadoras
                .Include(c => c.Components)
                .Where(c => c.Id == id).FirstOrDefault();

            if (computadora == null) return BadRequest(new { Message = "Computadora " + id + " not found" });

            var gabineteDuplicado = context.Computadoras
                .Where(c => c.Gabinete == dto.Gabinete && c.Id != id).Any();

            if (gabineteDuplicado) return BadRequest(new { Message = "PC_DUPLICATE" });
            computadora.Gabinete = dto.Gabinete;
            computadora.SalaId = dto.SalaId;
            computadora.Components.Clear();
            context.SaveChanges();

            if (dto.ComponentesSoftware != null)
                dto.ComponentesSoftware.ForEach(Id => computadora.Components.Add(context.Componentes.Where(c => c.Id == Id).First()));

            if (dto.ComponentsHardware != null)
                dto.ComponentsHardware.ForEach(Id => computadora.Components.Add(context.Componentes.Where(c => c.Id == Id).First()));

            context.SaveChanges();
            return Ok(computadora);

        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using (var context = new ITReportContext())
        {
            var pc = context.Computadoras.Where(sala => sala.Id == id).FirstOrDefault();
            if (pc == null) return NotFound(new { Message = "Computadora " + id + " does not exist" });

            context.Computadoras.Remove(pc);

            context.SaveChanges();
            return Ok();
        }

    }
    [HttpPost]
    public Computadora Create([FromBody] ComputadoraCreateDTO dto)
    {
        using (var context = new ITReportContext())
        {
            var newCompu = new Computadora();

            newCompu.Gabinete = dto.Gabinete;
            newCompu.SalaId = dto.SalaId;

            context.Computadoras.Add(newCompu);
            context.SaveChanges();
            return newCompu;
        }
    }
}
public class ComputadoraCreateDTOv2
{
    public string Gabinete { get; set; } = null!;
    public int SalaId { get; set; }
    public List<int>? ComponentesSoftware { get; set; }
    public List<int>? ComponentsHardware { get; set; }
}
public class ComputadoraCreateDTO
{
    public string Gabinete { get; set; } = null!;
    public int SalaId { get; set; }
}
