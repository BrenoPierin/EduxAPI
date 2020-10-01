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
    public class DicaController : ControllerBase
    {
        private readonly IDica _dica;

        public DicaController()
        {
            _dica = new DicaRepository();
        }

        // GET: api/Dica
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var dica = _dica.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (dica.Count == 0)
                    return NoContent();
                return Ok(dica);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }
            // GET: api/Dica/5
            [HttpGet("{id}")]
            public IActionResult Get(Guid id)
            {
                try
                {

                    var dica = _dica.BuscarPorID(id);

                    if (dica == null)
                        return NotFound();

                    return Ok(dica);
                }
                catch (Exception ex)
                {
                    //Caso ocorra um erro retorna BadRequest com a mensagem
                    //de erro
                    return BadRequest(ex.Message);
                }
            }

            // PUT: api/Dica/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public IActionResult Put(Guid id, Dica dica)
            {
                try
                {
                    _dica.Alterar(id, dica);

                    return Ok(dica);

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            // POST: api/Dica
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public IActionResult Post([FromForm] Dica dica)
            {
                try
                {
                    _dica.Cadastrar(dica);

                    return Ok(dica);
                }
                catch (Exception ex)
                {
                    //Caso ocorra um erro retorna BadRequest com a mensagem
                    //de erro
                    return BadRequest(ex.Message);
                }
            }


            // DELETE: api/Dica/5
            [HttpDelete("{id}")]
            public IActionResult Delete(Guid Id)
            {
                try
                {
                    _dica.Excluir(Id);

                    return Ok(Id);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
    }
}
