using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I9OpenWebApi.Interface;
using I9OpenWebApi.Models;
using I9OpenWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace I9OpenWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository = new ProdutosRespository();

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_produtoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_produtoRepository.ListarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "3,1")]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Produto novoCupom)
        {
            try
            {
                _produtoRepository.Cadastrar(novoCupom);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
        [Authorize(Roles = "3,1")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(Produto novosDados, int id)
        {
            try
            {
                novosDados.IdProduto = id;
                _produtoRepository.Atualizar(novosDados);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "1")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}