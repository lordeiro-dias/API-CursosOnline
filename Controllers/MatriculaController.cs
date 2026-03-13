using CursosOnline.Applications.Services;
using CursosOnline.DTOs.MatriculaDto;
using CursosOnline.Excpetions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursosOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaService _service;

        public MatriculaController(MatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerMatriculaDto>> Listar()
        {
            List<LerMatriculaDto> matriculas = _service.Listar();

            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public ActionResult<LerMatriculaDto> ObterPorId(int id)
        {
            try
            {
                LerMatriculaDto matriculas = _service.ObterPorId(id);
                return Ok(matriculas);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerMatriculaDto> Adicionar(CriarMatriculaDto matriculaDto)
        {
            try
            {
                LerMatriculaDto matricula = _service.Adicionar(matriculaDto);
                return Ok(matricula);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<LerMatriculaDto> Atualizar(int id, CriarMatriculaDto matriculaDto)
        {
            try
            {
                LerMatriculaDto matriculaAtualizado = _service.Atualizar(id, matriculaDto);
                return Ok(matriculaAtualizado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LerMatriculaDto> Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
