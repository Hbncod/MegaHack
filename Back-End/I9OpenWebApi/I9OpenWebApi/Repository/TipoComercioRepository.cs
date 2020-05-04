using I9OpenWebApi.Interface;
using I9OpenWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Repository
{
    class TipoComercioRepository : ITipoComercioRepository
    {
        MegaHackContext ctx = new MegaHackContext();
        public void Atualizar(TipoComercio novosDados)
        {
            TipoComercio antigosDados = ctx.TipoComercio.FirstOrDefault(Tc => Tc.IdTipoComercio == novosDados.IdTipoComercio);
            if(novosDados.Tipo != null)
            {
                antigosDados.Tipo = novosDados.Tipo;
            }
            ctx.TipoComercio.Update(antigosDados);
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoComercio novoTipo)
        {
            novoTipo.IdTipoComercio = 0;
            ctx.TipoComercio.Add(novoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoComercio tipoComercio = ctx.TipoComercio.FirstOrDefault(Tc => Tc.IdTipoComercio == id);
            ctx.TipoComercio.Remove(tipoComercio);
            ctx.SaveChanges();
        }

        public List<TipoComercio> Listar()
        {
            return ctx.TipoComercio.ToList();
        }

        public TipoComercio ListarPorId(int id)
        {
            return ctx.TipoComercio.FirstOrDefault(Tc => Tc.IdTipoComercio == id);
        }
    }
}
