using System.ComponentModel.DataAnnotations.Schema;

namespace personapi_donet.Models
{
    public partial class Estudio
    {
        public int IdProf { get; set; }
        public int CcPer { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Univer { get; set; }

        public virtual Persona CcPerNavigation { get; set; } = null!;
        public virtual Profesion IdProfNavigation { get; set; } = null!;

        [NotMapped]
        public object Estudios { get; internal set; }
    }
}
