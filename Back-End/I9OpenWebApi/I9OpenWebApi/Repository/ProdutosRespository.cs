using I9OpenWebApi.Interface;
using I9OpenWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I9OpenWebApi.Repository
{
    public class ProdutosRespository : IProdutoRepository
    {
        MegaHackContext ctx = new MegaHackContext();
        public void Atualizar(Produto novosDados)
        {
            Produto velhosDados = ctx.Produto.FirstOrDefault(p => p.IdProduto == novosDados.IdProduto);

            if(novosDados.NomeProduto != null)
            {
                velhosDados.NomeProduto = novosDados.NomeProduto;
            }
            ctx.Produto.Update(velhosDados);
            ctx.SaveChanges();
        }

        public void Cadastrar(Produto novoProduto)
        {
            novoProduto.IdProduto = 0;
            ctx.Produto.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto ProdutoDeletado = ctx.Produto.FirstOrDefault(p => p.IdProduto == id);
            ctx.Produto.Remove(ProdutoDeletado);
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produto.ToList();
        }

        public Produto ListarPorId(int id)
        {
            return ctx.Produto.FirstOrDefault(p => p.IdProduto == id);
        }
    }
}
