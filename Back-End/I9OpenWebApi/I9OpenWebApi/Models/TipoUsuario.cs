using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
