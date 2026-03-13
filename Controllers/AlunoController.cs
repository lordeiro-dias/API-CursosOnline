using CursosOnline.Applications.Services;
using CursosOnline.Domains;
using CursosOnline.DTOs.AlunoDto;
using CursosOnline.Excpetions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;

namespace CursosOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerAlunoDto>> Listar()
        {
            List<LerAlunoDto> alunos = _service.Listar();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerAlunoDto> ObterPorId(int id)
        {
            try
            {
                LerAlunoDto aluno = _service.ObterPorId(id);
                return Ok(aluno);
            }
            catch(DomainException ex)
            {
                return NotFound(ex.Message); 
            }
        }

        [HttpPost]
        public ActionResult<LerAlunoDto> Adicionar(CriarAlunoDto alunoDto)
        {
            try
            {
                LerAlunoDto alunos = _service.Adicionar(alunoDto);
                return Ok(alunos);
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<LerAlunoDto> Atualizar(int id, CriarAlunoDto alunoDto)
        {
            try
            {
                LerAlunoDto alunoAtualizado = _service.Atualizar(id, alunoDto);
                return Ok(alunoAtualizado);
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LerAlunoDto> Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch(DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
