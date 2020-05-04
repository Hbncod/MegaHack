using System;
using System.Collections.Generic;

namespace I9OpenWebApi.Models
{
    public partial class Cupom
    {
        public int IdCupom { get; set; }
        public int? Desconto { get; set; }
        public int? FkProduto { get; set; }
        public int? FkComercio { get; set; }

        public Comercio FkComercioNavigation { get; set; }
        public Produto FkProdutoNavigation { get; set; }
    }
}
