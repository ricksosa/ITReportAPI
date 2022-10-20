namespace ITReportAPI.Models
{
    public class Reporte : IBaseClass
    {
        public int Id { get; set; }
        public DateTime FechaDeReporte { get; set; }
        public EstadoReporte  Estado { get; set; } = null!;
        public string ComentariosReporte { get; set; } = null!;
        public string ComentariosAdmin { get; set; } = null!;
        public CategoriaReporte Categoria { get; set; } = null!;
        public int IdSala { get; set; }
        public Sala Sala { get; set; } = null!;
        public int IdComputadora { get; set; }
        public Computadora Computadora { get; set; } = null!;
        public DateTime FechaActualizacion { get; set; }
        public TipoDeIncidente Incidente { get; set; } = null!; 


    }
    public class TipoDeIncidente
    {
        public int Id { get; set;}
        public string Nombre { get; set; } = null!;
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