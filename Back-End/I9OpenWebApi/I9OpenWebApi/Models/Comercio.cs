using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace I9OpenWebApi.Models
{
    public partial class Comercio
    {
        public Comercio()
        {
            Cupom = new HashSet<Cupom>();
        }

        public int IdComercio { get; set; }
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "O máximo de caracteres permitidos no campo \"Nome Fantasia\" é 200")]
        [Required(ErrorMessage = "O Campo \"Nome Fantasia\" é obrigatório")]
        public string NomeFantasia { get; set; }
        [StringLength(14,MinimumLength =14, ErrorMessage ="O CNPJ deve conter 14 digitos")]
        [Required(ErrorMessage = "O Campo \"CNPJ\" é obrigatório")]
        public string Cnpj { get; set; }
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 digitos")]
        [Required(ErrorMessage = "O Campo \"CEP\" é obrigatório")]
        public string Cep { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve conter 2 digitos")]
        [Required(ErrorMessage = "O Campo \"UF\" é obrigatório")]
        public string Uf { get; set; }
        [StringLength(200, ErrorMessage = "O máximo de caracteres permitidos no campo \"Cidade\" é 200")]
        [Required(ErrorMessage = "O Campo \"Cidade\" é obrigatório")]
        public string Cidade { get; set; }
        [StringLength(200, ErrorMessage = "O máximo de caracteres permitidos no campo \"Bairro\" é 200")]
        [Required(ErrorMessage = "O Campo \"Bairro\" é obrigatório")]
        public string Bairro { get; set; }
        [StringLength(200, ErrorMessage = "O máximo de caracteres permitidos no campo \"Logradouro\" é 200")]
        [Required(ErrorMessage = "O Campo \"Logradouro\" é obrigatório")]
        public string Logradouro { get; set; }
        [StringLength(10, ErrorMessage = "O máximo de caracteres permitidos no campo \"Numero\" é 10")]
        [Required(ErrorMessage = "O Campo \"Numero\" é obrigatório")]
        public string Numero { get; set; }
        [StringLength(20, ErrorMessage = "Informações do campo \"Telefone Fixo\" são inválidas")]
        [Required(ErrorMessage = "O Campo \"Telefone Fixo\" é obrigatório")]
        public string TelefoneFixo { get; set; }
        [StringLength(20, ErrorMessage = "Informações do campo \"Telefone Celular\" são inválidas")]
        [Required(ErrorMessage = "O Campo \"Telefone Celular\" é obrigatório")]
        public string TelefoneCelular { get; set; }
        [StringLength(350, ErrorMessage = "O máximo de caracteres permitidos no campo \"Descricao\" é 350")]
        [Required(ErrorMessage = "O Campo \"Descricao\" é obrigatório")]
        public string Descricao { get; set; }
        public int FkUsuario { get; set; }
        [Required(ErrorMessage = "O Campo \"Tipo de Comercio\" é obrigatório")]
        public int FkTipoComercio { get; set; }
        public TipoComercio FkTipoComercioNavigation { get; set; }
        public Usuario FkUsuarioNavigation { get; set; }
        public ICollection<Cupom> Cupom { get; set; }
    }
}
