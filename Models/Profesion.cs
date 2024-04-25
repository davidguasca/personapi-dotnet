namespace personapi_donet.Models
{
    public partial class Profesion
    {
        public Profesion()
        {
            Estudios = new HashSet<Estudio>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Des { get; set; }

        public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
