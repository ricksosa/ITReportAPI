namespace ITReportAPI.Models
{
    public class Reporte : IBaseClass
    {
        public int Id { get; set; }
        public DateTime FechaDeReporte { get; set; }
        public EstadoReporte  Estado { get; set; } = null!;
        public int EstadoId { get; set; }
        public string ComentariosReporte { get; set; } = null!;
        public string? ComentariosAdmin { get; set; } = null!;
        public CategoriaReporte Categoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        public Computadora Computadora { get; set; } = null!;
        public int ComputadoraId { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public TipoDeIncidente Incidente { get; set; } = null!; 
        public int TipoDeIncidenteId { get; set; }


    }
    public class TipoDeIncidente
    {
        public int Id { get; set;}
        public string Nombre { get; set; } = null!;
        public CategoriaReporte CategoriaReporte { get; set; } = null!;
        public int CategoriaReporteId { get; set; }
    }
    public class CategoriaReporte 
    {
        public int Id { get; set; }
        public string Nombre{ get; set; } = null!;
    }
    public class EstadoReporte
    {
        public int Id { get; set; }
        public string Nombre{ get; set; } = null!;
    }
}