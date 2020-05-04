using I9Open.Interface;
using I9OpenWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9Open.Repository
{
    public class ComercioRepository : IComercioRepository
    {
        private MegaHackContext ctx = new MegaHackContext();
        public void Atualizar(Comercio NovosDados)
        {
            Comercio DadosAntigos = ctx.Comercio.FirstOrDefault(C => C.IdComercio == NovosDados.IdComercio);

            if (NovosDados.NomeFantasia != null)
            {
                DadosAntigos.NomeFantasia = NovosDados.NomeFantasia;
            }
            if (NovosDados.Cnpj != null)
            {
                DadosAntigos.Cnpj = NovosDados.Cnpj;
            }
            if (NovosDados.Cep != null)
            {
                DadosAntigos.Cep = NovosDados.Cep;
            }
            if (NovosDados.Uf != null)
            {
                DadosAntigos.Uf = NovosDados.Uf;
            }
            if (NovosDados.Cidade != null)
            {
                DadosAntigos.Cidade = NovosDados.Cidade;
            }
            if (NovosDados.Bairro != null)
            {
                DadosAntigos.Bairro = NovosDados.Bairro;
            }
            if (NovosDados.Logradouro != null)
            {
                DadosAntigos.Logradouro = NovosDados.Logradouro;
            }
            if (NovosDados.Numero != null)
            {
                DadosAntigos.Numero = NovosDados.Numero;
            }
            if (NovosDados.TelefoneFixo != null)
            {
                DadosAntigos.TelefoneFixo = NovosDados.TelefoneFixo;
            }
            if (NovosDados.TelefoneCelular != null)
            {
                DadosAntigos.TelefoneCelular = NovosDados.TelefoneCelular;
            }
            if (NovosDados.Descricao != null)
            {
                DadosAntigos.Descricao = NovosDados.Descricao;
            }
            ctx.Comercio.Update(DadosAntigos);
            ctx.SaveChanges();
        }

        public void Cadastrar(Comercio NovoComercio)
        {
            ctx.Comercio.Add(NovoComercio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Comercio ComercioDeletado = ctx.Comercio.FirstOrDefault(C => C.IdComercio == id);

            if(ComercioDeletado != null)
            {
                ctx.Comercio.Remove(ComercioDeletado);
                ctx.SaveChanges();
            }
        }

        public List<Comercio> Listar()
        {
            return ctx.Comercio.Include(c => c.FkUsuarioNavigation).Include(c => c.FkTipoComercioNavigation).ToList();
        }

        public Comercio ListarPorId(int id)
        {
            return ctx.Comercio.Include(c => c.FkUsuarioNavigation).Include(c => c.FkTipoComercioNavigation).FirstOrDefault(C => C.IdComercio == id);
        }
    }
}
