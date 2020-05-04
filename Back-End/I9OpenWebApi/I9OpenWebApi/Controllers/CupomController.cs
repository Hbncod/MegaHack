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

namespace I9OpenWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private ICupomRepository _cupomRepository = new CupomRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_cupomRepository.Listar());
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
                return Ok(_cupomRepository.ListarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "3")]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Cupom novoCupom)
        {
            try
            {
                _cupomRepository.Cadastrar(novoCupom);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
        [Authorize(Roles ="3")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(Cupom novosDados,int id)
        {
            try
            {
                novosDados.IdCupom = id;
                _cupomRepository.Atualizar(novosDados);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "3")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _cupomRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        
    }
}