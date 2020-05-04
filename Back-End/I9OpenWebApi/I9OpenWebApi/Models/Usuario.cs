using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comercio = new HashSet<Comercio>();
            Plano = new HashSet<Plano>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int FkTipoUsuario { get; set; }

        public TipoUsuario FkTipoUsuarioNavigation { get; set; }
        public ICollection<Comercio> Comercio { get; set; }
        public ICollection<Plano> Plano { get; set; }
    }
}
