using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ITReportAPI.Models
{
    [DataContract]
    public class Admin : IBaseClass
    { 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; } = null!;
        [DataMember]
        public string Apellido { get; set; } = null!;
        [DataMember]
        public string Usuario { get; set; } = null!;
        [JsonIgnore]
        public string password { get; set; } = null!;
    }
}