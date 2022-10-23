using ITReportAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/admins")]
public class AdminController : ControllerBase
{
    [HttpGet]
    public List<Admin> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Admins.ToList();
        }
    }
    [HttpGet("{id}")]
    public Admin Get(int id)
    {
        using (var context = new ITReportContext())
        {
            var admins = context.Admins.Where(s => s.Id == id).FirstOrDefault();
            if (admins == null) throw new Exception("Admin not found");
            return admins;
        }
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] AdminCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var admin = context.Admins.Where(s => s.Id == id).FirstOrDefault();
            if (admin == null) return NotFound(new { Message = "No se encontró al administrador"});
            if (admin.password != dto.Password) return Unauthorized(new {Message = "La contraseña es incorrecta"});

            admin.Nombre = dto.Nombre;
            admin.Apellido = dto.Apellido;
            admin.Usuario = dto.Usuario;

            context.SaveChanges();

            return Ok(admin);
        }
    }
    [HttpPost]
    public Admin Create([FromBody] AdminCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var admin = new Admin();

            admin.Nombre = dto.Nombre;
            admin.Apellido = dto.Apellido;
            admin.Usuario = dto.Usuario;
            admin.password = dto.Password;

            context.Admins.Add(admin);

            context.SaveChanges();
            return admin;
        }
    }
}
public class AdminCreateDto
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Usuario { get; set; } = null!;
    public string? Password { get; set; } = null!;
}
