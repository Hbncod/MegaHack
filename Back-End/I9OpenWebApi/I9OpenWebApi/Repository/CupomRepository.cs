using I9Open.Interface;
using I9OpenWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9Open.Repository
{
    public class CupomRepository : ICupomRepository
    {
        private MegaHackContext ctx = new MegaHackContext();
        public void Atualizar(Cupom NovosDados)
        {
            Cupom DadosAntigos = ctx.Cupom.FirstOrDefault(c => c.IdCupom == NovosDados.IdCupom);

            if (NovosDados.Desconto != null)
            {
                DadosAntigos.Desconto = NovosDados.Desconto;
            }
            if (NovosDados.FkProduto != null)
            {
                DadosAntigos.FkProduto = NovosDados.FkProduto;
            }
            ctx.Cupom.Update(DadosAntigos);
            ctx.SaveChanges();
        }

        public void Cadastrar(Cupom novoCupom)
        {
            ctx.Cupom.Add(novoCupom);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cupom CupomDeletado = ctx.Cupom.FirstOrDefault(C => C.IdCupom == id);

            if (CupomDeletado != null)
            {
                ctx.Cupom.Remove(CupomDeletado);
                ctx.SaveChanges();
            }
        }

        public List<Cupom> Listar()
        {
            return ctx.Cupom.Include(c => c.FkProdutoNavigation).Include(c => c.FkComercioNavigation).ToList();
        }

        public Cupom ListarPorId(int id)
        {
            return ctx.Cupom.Include(c => c.FkProdutoNavigation).Include(c => c.FkComercioNavigation).FirstOrDefault(c=> c.IdCupom == id);
        }
    }
}
