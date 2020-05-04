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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_usuarioRepository.ListarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
        [Authorize]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(Usuario novosDados, int id)
        {
            try
            {
                novosDados.IdUsuario = id;
                _usuarioRepository.Atualizar(novosDados);
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
                _usuarioRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}