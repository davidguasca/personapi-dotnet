﻿namespace personapi_donet.Models
{
    public partial class Telefono
    {
        public string Num { get; set; } = null!;
        public string? Oper { get; set; }
        public int? Duenio { get; set; }

        public virtual Persona? DuenioNavigation { get; set; }
    }
}
