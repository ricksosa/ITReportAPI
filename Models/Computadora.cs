namespace ITReportAPI.Models
{
    public class Computadora : IBaseClass
    {
        public int Id { get; set; }
        public string Gabinete { get; set; } = null!;
        public int SalaId { get; set; }
        public Sala Sala { get; set; } = null!;
        public ICollection<Componente> Components { get; set; } = null!;
        public ICollection<Reporte> Reportes { get; set; } = null!;

    }
}