using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Repositories;
using EduxAPI.Interfaces;

namespace EduxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICurso _curso;

        public CursosController()
        {
            _curso = new CursoRepository();
        }

        // GET: api/Cursos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var curso = _curso.ListarTodos() ;

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (curso.Count == 0)
                    return NoContent();
                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var curso = _curso.BuscarPorID(id);

                if (curso == null)
                return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Curso curso)
        {
            try
            {
                _curso.Alterar(id, curso);

                return Ok(curso);
            
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Cursos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromForm] Curso curso)
        {
            try
            {
                _curso.Cadastrar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _curso.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
