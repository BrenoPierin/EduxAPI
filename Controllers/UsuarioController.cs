using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using EduxAPI.Repositories;

namespace EduxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var usuario = _usuario.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (usuario.Count == 0)
                    return NoContent();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var usuario = _usuario.BuscarPorID(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                _usuario.Alterar(id, usuario);

                return Ok(usuario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromForm] Usuario usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _usuario.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
