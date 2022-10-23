namespace ITReportAPI.Models
{
    public class Componente : IBaseClass
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public CategoriaComputadora Categoria { get; set; } = null!;
        public int CategoriaId { get; set; }
    }
}