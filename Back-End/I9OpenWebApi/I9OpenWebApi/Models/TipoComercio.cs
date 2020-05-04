using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class TipoComercio
    {
        public TipoComercio()
        {
            Comercio = new HashSet<Comercio>();
        }

        public int IdTipoComercio { get; set; }
        public string Tipo { get; set; }

        public ICollection<Comercio> Comercio { get; set; }
    }
}
