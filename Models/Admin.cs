namespace ITReportAPI.Models
{
    public class Admin
    { 
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Usuario { get; set; } = null!;
    }
}