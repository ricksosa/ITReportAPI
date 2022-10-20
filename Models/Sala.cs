namespace ITReportAPI.Models
{
    public class Sala : IBaseClass
    {
        public int Id { get; set; }
        public string Edificio { get; set; } = null!;
        public ICollection<Computadora> Computadoras { get; set; } = null!;
    }

}