using CursosOnline.Applications.Services;
using CursosOnline.DTOs.CursoDto;
using CursosOnline.Excpetions;
using CursosOnline.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursosOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _service;

        public CursoController(CursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerCursoDto>> Listar()
        {
            List<LerCursoDto> cursos = _service.Listar();

            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerCursoDto> ObterPorId(int id)
        {
            try
            {
                LerCursoDto curso = _service.ObterPorId(id);
                return Ok(curso);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerCursoDto> Adicionar(CriarCursoDto cursoDto)
        {
            try
            {
                _service.Adicionar(cursoDto);
                return Ok();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<LerCursoDto> Atualizar(int id, CriarCursoDto cursoDto)
        {
            try
            {
                _service.Atualizar(id, cursoDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LerCursoDto> Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
