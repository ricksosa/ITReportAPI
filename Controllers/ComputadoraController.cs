using System.Net;
using ITReportAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/computadoras")]
public class ComputadoraController : ControllerBase
{
    public List<Computadora> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Computadoras.ToList();
        }
    }
    [HttpGet("{id}")]
    public Computadora GetById(int id)
    {
        using(var context = new ITReportContext())
        {
            var computadora = context.Computadoras.Where(c => c.Id == id).FirstOrDefault();
            if(computadora == null) throw new Exception("Computadora not found");
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
    [HttpPost("search")]
    public List<Computadora> Search(SearchDto search)
    {
        using (var context = new ITReportContext())
        {
            return context.Computadoras.Where(c => c.Gabinete.ToLower().Contains(search.Value.ToLower())).ToList();
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
public class ComputadoraCreateDTO
{
    public string Gabinete { get; set; } = null!;
    public int SalaId { get; set; }
}
