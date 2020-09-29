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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicao;

        public InstituicaoController()
        {
            _instituicao = new InstituicaoRepository();
        }

        // GET: api/Instituicao
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var instituicao = _instituicao.ListarTodos();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (instituicao.Count == 0)
                    return NoContent();
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Instituicao/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var instituicao = _instituicao.BuscarPorID(id);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Instituicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicao.Alterar(id, instituicao);

                return Ok(instituicao);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Instituicao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromForm] Instituicao instituicao)
        {
            try
            {
                _instituicao.Cadastrar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Instituicao/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _instituicao.Excluir(Id);

                return Ok(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
