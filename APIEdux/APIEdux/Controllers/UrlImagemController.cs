using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IUrlImagem _UrlRepository;

        public EventosController(IUrlImagem UrlRepository)
        {
            _UrlRepository = UrlRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Cadastrar(UrlImagemDTO urlimagem)
        {
            try
            {
                UrlImagem evt = new UrlImagem();
                evt.Texto = UrlImagem.Texto;
                evt.UrlImagem = urlimagem.UrlImagem;

                _UrlRepository.Adicionar(evt);

                return Ok(new { data = evt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Alterar(Guid id, UrlImagemDTO urlimagem)
        {
            try
            {
                UrlImagem evt = _UrlImagemRepository.BuscarPorId(id);

                if (evt == null)
                {
                    return NotFound();
                }

                evt.Texto = urlimagem.Texto;
                evt.UrlImagem = urlimagem.UrlImagem;
                

                _UrlImagemRepository.Atualizar(evt);

                return Ok(new { data = evt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                UrlImagem cat = _UrlImagemRepository.BuscarPorId(id);

                if (cat == null)
                {
                    return NotFound();
                }

                _UrlImagemRepository.Remover(id);

                return Ok(new { data = cat });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var UrlImagem = _UrlImagemRepository.ObterTodos(new string[] { "Categoria" });

                return Ok(new { data = UrlImagem });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                UrlImagem cat = _UrlImagemRepository.BuscarPorId(id);

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(new { data = cat });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}