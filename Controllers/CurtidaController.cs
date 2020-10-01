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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtida _curtida;

        public CurtidaController()
        {
            _curtida = new CurtidaRepository();
        }

        // GET: api/Curtida
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var curtida = _curtida.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (curtida.Count == 0)
                    return NoContent();
                return Ok(curtida);
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

                var curtida = _curtida.BuscarPorID(id);

                if (curtida == null)
                    return NotFound();

                return Ok(curtida);
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
        public IActionResult Put(Guid id, Curtida curtida)
        {
            try
            {
                _curtida.Alterar(id, curtida);

                return Ok(curtida);

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
        public IActionResult Post([FromForm] Curtida curtida)
        {
            try
            {
                _curtida.Cadastrar(curtida);

                return Ok(curtida);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
