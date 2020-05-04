using I9OpenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Interface
{
    interface ITipoComercioRepository
    {
        List<TipoComercio> Listar();

        TipoComercio ListarPorId(int id);

        void Cadastrar(TipoComercio novoTipo);

        void Atualizar(TipoComercio novosDados);

        void Deletar(int id);
    }
}
