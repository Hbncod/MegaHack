using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Cupom = new HashSet<Cupom>();
        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }

        public ICollection<Cupom> Cupom { get; set; }
    }
}
