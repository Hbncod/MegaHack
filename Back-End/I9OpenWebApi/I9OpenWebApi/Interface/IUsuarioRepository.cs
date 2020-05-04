using I9OpenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Interface
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario ListarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(Usuario novosDados);

        void Deletar(int id);

        Usuario BuscarPorEmaileSenha(string senha, string email);
    }
}
