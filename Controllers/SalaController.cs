using ITReportAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/salas")]
public class SalaController : ControllerBase
{
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
            if(sala == null) throw new Exception("Sala not found");
            return sala;
        }
    }
    [HttpPost("search")]
    public List<Sala> Search([FromBody] SearchDto search)
    {
        using (var context = new ITReportContext())
        {
            return context.Salas
                .Where(s => s.Nombre.ToLower().Contains(search.Value.ToLower()))
                .ToList();
        }
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
