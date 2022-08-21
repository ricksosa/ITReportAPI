namespace ITReportAPI.Models
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public CategoriaComputadora Categoria { get; set; } = null!;
    }
}