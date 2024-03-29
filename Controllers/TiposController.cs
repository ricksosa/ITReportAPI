using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/tipos")]
[Authorize]
public class TiposController : ControllerBase
{
    [HttpGet("incidentes")]
    [AllowAnonymous]
    public List<TipoDeIncidente> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.TiposDeIncidente.ToList();
        }
    }
    [HttpGet("categorias")]
    [AllowAnonymous]
    public List<CategoriaReporte> GetCategoriaReportes()
    {
        using (var context = new ITReportContext())
        {
            return context.CategoriasReporte.ToList();
        }
    }
}