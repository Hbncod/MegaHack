using I9OpenWebApi.Interface;
using I9OpenWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MegaHackContext ctx = new MegaHackContext();
        public void Atualizar(Usuario novosDados)
        {
            Usuario usuarioAntigo = ctx.Usuario.FirstOrDefault(U => U.IdUsuario == novosDados.IdUsuario);

            if (novosDados.Nome != null)
            {
                usuarioAntigo.Nome = novosDados.Nome;
            }
            if (novosDados.Email != null)
            {
                usuarioAntigo.Email = novosDados.Email;
            }
            if (novosDados.Senha != null)
            {
                usuarioAntigo.Senha = novosDados.Senha;
            }
            if (novosDados.Telefone != null)
            {
                usuarioAntigo.Telefone = novosDados.Telefone;
            }

            ctx.Usuario.Update(usuarioAntigo);
            ctx.SaveChanges();
        }

        public Usuario ListarPorId(int id)
        {
              return ctx.Usuario.Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Rg = u.Rg,
                    Cpf = u.Cpf,
                    FkTipoUsuario = u.FkTipoUsuario,
                    Telefone = u.Telefone,

                    FkTipoUsuarioNavigation = new TipoUsuario()
                    {
                        Tipo = u.FkTipoUsuarioNavigation.Tipo
                    }
                }).FirstOrDefault(U => U.IdUsuario == id);
           
           // return ctx.Usuario.FirstOrDefault(U => U.IdUsuario == id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            NovoUsuario.IdUsuario = 0;
            ctx.Usuario.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioDeletado = ctx.Usuario.FirstOrDefault(U => U.IdUsuario == id);
            ctx.Remove(usuarioDeletado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.Select(u => new Usuario()
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                Rg = u.Rg,
                Cpf = u.Cpf,
                FkTipoUsuario = u.FkTipoUsuario,
                Telefone = u.Telefone,

                FkTipoUsuarioNavigation = new TipoUsuario()
                {
                    Tipo = u.FkTipoUsuarioNavigation.Tipo
                }
            }).ToList();
        }

        public Usuario BuscarPorEmaileSenha(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(U => U.Email == email && U.Senha == senha);
        }
    }
}
