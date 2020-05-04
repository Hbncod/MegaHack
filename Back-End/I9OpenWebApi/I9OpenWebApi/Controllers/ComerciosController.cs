using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I9Open.Interface;
using I9Open.Repository;
using I9OpenWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace I9Open.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComerciosController : ControllerBase
    {
        private IComercioRepository _comercioRepository = new ComercioRepository();

        /// <summary>
        /// Lista todos os comerios
        /// </summary>
        /// <returns>uma lista de comercio</returns>
        /// api/comercio
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_comercioRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Busca um comercio por seu id
        /// </summary>
        /// <param name="id">id referente ao comercio a ser buscado</param>
        /// <returns>o comercio referente ao id informado</returns>
        /// api/comercio/id
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_comercioRepository.ListarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Cadastra um novo comercio
        /// </summary>
        /// <param name="novoComercio">Dados do novo comercio</param>
        /// <returns>status code Created</returns>
        /// api/comercio/cadastro
        [HttpPost("cadastro")]
        public IActionResult Cadastrar(Comercio novoComercio)
        {
            try
            {
                _comercioRepository.Cadastrar(novoComercio);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Deleta um comercio
        /// </summary>
        /// <param name="id">Id do comercio a ser deletado</param>
        /// <returns>status code 200</returns>
        /// api/comercio/deletar
        [Authorize(Roles ="1")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _comercioRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Atualiza os dados de um comercio
        /// </summary>
        /// <param name="id">id do comercio a ser atualizado</param>
        /// <param name="novosDados">novos dados do comercio</param>
        /// <returns></returns>
        /// api/comercio/atualizar/id
        [Authorize(Roles ="3")]
        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, Comercio novosDados)
        {
            try
            {
                novosDados.IdComercio = id;
                _comercioRepository.Atualizar(novosDados);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}