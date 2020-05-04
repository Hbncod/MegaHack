using I9OpenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Interface
{
    interface IProdutoRepository
    {
        List<Produto> Listar();

        Produto ListarPorId(int id);

        void Deletar(int id);

        void Atualizar(Produto novosDados);

        void Cadastrar(Produto novoProduto);
    }
}
