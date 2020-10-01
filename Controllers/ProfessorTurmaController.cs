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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurma _ProfTurma;

        public ProfessorTurmaController()
        {
            _ProfTurma = new ProfessorTurmaRepsitory();
        }

        // GET: api/ProfessorTurma
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var profTurma = _ProfTurma.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (profTurma.Count == 0)
                    return NoContent();
                return Ok(profTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ProfessorTurma/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var profTurma = _ProfTurma.BuscarPorID(id);

                if (profTurma == null)
                    return NotFound();

                return Ok(profTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/ProfessorTurma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProfessorTurma profTurma)
        {
            try
            {
                _ProfTurma.Alterar(id, profTurma);

                return Ok(profTurma);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/ProfessorTurma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromForm] ProfessorTurma profTurma)
        {
            try
            {
                _ProfTurma.Cadastrar(profTurma);

                return Ok(profTurma);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/ProfessorTurma/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _ProfTurma.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
