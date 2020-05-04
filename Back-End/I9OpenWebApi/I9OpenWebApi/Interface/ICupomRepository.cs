
using I9OpenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9Open.Interface
{
    interface ICupomRepository
    {
        List<Cupom> Listar();

        Cupom ListarPorId(int id);

        void Deletar(int id);

        void Atualizar(Cupom NovosDados);

        void Cadastrar(Cupom novoCupom);
    }
}
