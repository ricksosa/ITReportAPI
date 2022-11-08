using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/Componentes")]
[Authorize]
public class ComponenteController : ControllerBase
{
    [HttpGet]
    public List<Componente> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Componentes.ToList();
        }
    }
    [HttpGet("{Id}")]
    public Componente? GetById(int Id)
    {
        using (var context = new ITReportContext())
        {
            return context.Componentes.Where(componente => componente.Id == Id).FirstOrDefault();
        }
    }
    [HttpPost]
    public Componente Create(ComponenteDto dto)
    {
        using (var context = new ITReportContext())
        {

            var componente = new Componente();

            componente.CategoriaId = (int)dto.CategoriaId;
            componente.Nombre = dto.Nombre;
            componente.Numero = dto.Numero;
            
            context.Componentes.Add(componente);
            return componente;
        }


    }
    public class ComponenteDto
    {
        public string Nombre { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public CategoriaComponent CategoriaId { get; set; }
    }
}
