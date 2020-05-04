
using I9OpenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9Open.Interface
{
    interface IComercioRepository
    {
        List<Comercio> Listar();

        Comercio ListarPorId(int id);

        void Cadastrar(Comercio NovoComercio);

        void Deletar(int id);

        void Atualizar(Comercio NovosDados);
    
    }
}
