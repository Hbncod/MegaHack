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
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComercioController : ControllerBase
    {
        private ITipoComercioRepository _tipoComercioRepository = new TipoComercioRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoComercioRepository.Listar());
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
                return Ok(_tipoComercioRepository.ListarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "3,1")]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(TipoComercio novoTipo)
        {
            try
            {
                _tipoComercioRepository.Cadastrar(novoTipo);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
        [Authorize(Roles = "3,1")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(TipoComercio novosDados, int id)
        {
            try
            {
                novosDados.IdTipoComercio = id;
                _tipoComercioRepository.Atualizar(novosDados);
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
                _tipoComercioRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


    }
}