using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ITReportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ITReportAPI.Controllers;
[ApiController]
[Route("/api/admins")]
[Authorize]

public class AdminController : ControllerBase
{
    private readonly IConfiguration configuration;
    public AdminController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    [HttpGet]
    public List<Admin> GetAll()
    {
        using (var context = new ITReportContext())
        {
            return context.Admins.ToList();
        }
    }
    [HttpPost("token")]
    [AllowAnonymous]
    public IActionResult CreateToken(CreateTokenDto dto)
    {
        using (var context = new ITReportContext())
        {
            var user = context.Admins.Where(a => a.Usuario == dto.Usuario && a.password == dto.Password).FirstOrDefault();
            if (user == null) return Unauthorized();
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, dto.Usuario),
                new Claim(JwtRegisteredClaimNames.Email, dto.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return Ok(stringToken);

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
            if (admin == null) return NotFound(new { Message = "No se encontró al administrador" });
            if (admin.password != dto.Password) return Unauthorized(new { Message = "ERR_PASSWORD" });

            admin.Nombre = dto.Nombre;
            admin.Apellido = dto.Apellido;
            admin.Usuario = dto.Usuario;

            if (!string.IsNullOrEmpty(dto.NewPassword))
                admin.password = dto.NewPassword;

            context.SaveChanges();

            return Ok(admin);
        }
    }
    [HttpPost]
    public IActionResult Create([FromBody] AdminCreateDto dto)
    {
        using (var context = new ITReportContext())
        {
            var admin = new Admin();

            admin.Nombre = dto.Nombre;
            admin.Apellido = dto.Apellido;
            admin.Usuario = dto.Usuario;
            if (dto.Password == null) return BadRequest(new { Message = "No se ingresó una contraseña" });
            admin.password = dto.Password;

            context.Admins.Add(admin);

            context.SaveChanges();
            return Ok(admin);
        }
    }
}
public class AdminCreateDto
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Usuario { get; set; } = null!;
    public string? Password { get; set; } = null!;
    public string? NewPassword { get; set; } = null!;
}
public class TokenResponse
{

}
public class CreateTokenDto
{
    public string Usuario { get; set; } = null!;
    public string Password { get; set; } = null!;
}
