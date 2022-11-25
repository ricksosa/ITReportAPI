using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/Componentes")]
public class ComponenteController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public List<Componente> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Componentes.ToList();
        }
    }
    [HttpGet("unassigned")]
    public List<Componente> GetAllUnassigned()
    {
        using (var context = new ITReportContext())
        {
            return context.Componentes
                .Where(componente => componente.Computadoras.Count == 0)
                .ToList();
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
    [AllowAnonymous]
    [HttpGet("computadora/{IdComputadora}")]
    public IActionResult GetComponentesFromComputador(int IdComputadora)
    {
        using (var context = new ITReportContext())
        {
            var computadora = context.Computadoras
                .Include(c => c.Components)
                .Where(computadora => computadora.Id == IdComputadora)
                .SingleOrDefault();
            if (computadora == null) NotFound(new { Message = "No se encontró la computadora " + IdComputadora });
            else return Ok(computadora.Components);
        }
        return Ok(new List<Componente>());
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ComponenteDto dto)
    {

        using (var context = new ITReportContext())
        {

            var componente = context.Componentes.Where(componente => componente.Id == id).FirstOrDefault();
            if (componente == null) return NotFound(new { Message = "Component " + id + " does not exist" });

            var componenteDuplicado = context.Componentes
                .Where(componente => componente.Numero == dto.Numero && componente.Id != id).Any();

            if (componenteDuplicado) return BadRequest(new { Message = "COMPONENT_DUPLICATE" });

            
            componente.CategoriaId = (int)dto.CategoriaId;
            componente.Nombre = dto.Nombre;
            componente.Numero = dto.Numero;

            context.SaveChanges();
            return Ok(componente);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using (var context = new ITReportContext())
        {
            var componente = context.Componentes.Where(componente => componente.Id == id).FirstOrDefault();
            if (componente == null) return NotFound(new { Message = "Component " + id + " does not exist" });

            context.Componentes.Remove(componente);

            context.SaveChanges();
            return Ok();
        }

    }
    [HttpPost]
    public IActionResult Create(ComponenteDto dto)
    {
        using (var context = new ITReportContext())
        {

            var componente = new Componente();

            componente.CategoriaId = (int)dto.CategoriaId;
            componente.Nombre = dto.Nombre;
            componente.Numero = dto.Numero;

            if (context.Componentes.Any(c => c.Numero == dto.Numero))
            {
                return BadRequest(new { Message = "Ya existe un componente con ese número" });
            }

            context.Componentes.Add(componente);
            context.SaveChanges();
            return Ok(componente);
        }


    }
    public class ComponenteDto
    {
        public string Nombre { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public CategoriaComponent CategoriaId { get; set; }
    }
}
