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
    public class TurmaController : ControllerBase
    {
        private readonly ITurma _turma;

        public TurmaController()
        {
            _turma = new TurmaRepository();
        }

        // GET: api/Turma
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var turma = _turma.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (turma.Count == 0)
                    return NoContent();
                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Turma/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var turma = _turma.BuscarPorID(id);

                if (turma == null)
                    return NotFound();

                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Turma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Turma turma)
        {
            try
            {
                _turma.Alterar(id, turma);

                return Ok(turma);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Turma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromForm] Turma turma)
        {
            try
            {
                _turma.Cadastrar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Turma/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _turma.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
