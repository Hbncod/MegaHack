using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class Plano
    {
        public int IdPlano { get; set; }
        public DateTime? Fim { get; set; }
        public bool? Estado { get; set; }
        public int FkUsuario { get; set; }

        public Usuario FkUsuarioNavigation { get; set; }
    }
}
