using CursosOnline.Applications.Services;
using CursosOnline.DTOs.InstrutorDto;
using CursosOnline.Excpetions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursosOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrutorController : ControllerBase
    {
        private readonly InstrutorService _service;

        public InstrutorController(InstrutorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerInstrutorDto>> Listar()
        {
            List<LerInstrutorDto> instrutors = _service.Listar();

            return Ok(instrutors);
        }

        [HttpGet("{id}")]
        public ActionResult<LerInstrutorDto> ObterPorId(int id)
        {
            try
            {
                LerInstrutorDto instrutor = _service.ObterPorId(id);
                return Ok(instrutor);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<LerInstrutorDto> Adicionar(CriarInstrutorDto instrutorDto)
        {
            try
            {
                LerInstrutorDto instrutor = _service.Adicionar(instrutorDto);
                return Ok(instrutor);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<LerInstrutorDto> Atualizar(int id, CriarInstrutorDto instrutorDto)
        {
            try
            {
                LerInstrutorDto instrutorAtualizado = _service.Atualizar(id, instrutorDto);
                return Ok(instrutorAtualizado);
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<LerInstrutorDto> Remover(int id)
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
