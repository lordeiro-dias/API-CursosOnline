using CursosOnline.Applications.Conversoes;
using CursosOnline.Domains;
using CursosOnline.DTOs.CursoDto;
using CursosOnline.Excpetions;
using CursosOnline.Interfaces;

namespace CursosOnline.Applications.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        public List<LerCursoDto> Listar()
        {
            List<Curso> cursos = _repository.Listar();

            List<LerCursoDto> cursosDto = cursos.Select(CursoParaDto.ConverterParaDto).ToList();

            return cursosDto;
        }

        public LerCursoDto ObterPorId(int id)
        {
            Curso curso = _repository.ObterPorId(id);

            if(curso == null)
            {
                throw new DomainException("Curso não encontrado.");
            }

            return CursoParaDto.ConverterParaDto(curso);
        }

        public static void ValidarCadastro(CriarCursoDto cursoDto)
        {
            if(string.IsNullOrEmpty(cursoDto.Nome))
            {
                throw new DomainException("Nome é obrigatório");
            }

            if(string.IsNullOrEmpty(cursoDto.Descricao))
            {
                throw new DomainException("Descrição é obrigatória");
            }

            if(string.IsNullOrEmpty(cursoDto.cargaHoraria))
            {
                throw new DomainException("Carga Horária é obrigatória");
            }
        }

        public LerCursoDto Adicionar(CriarCursoDto cursoDto)
        {
            Curso curso = new Curso
            {
                Nome = cursoDto.Nome,
                Descricao = cursoDto.Descricao,
                CargaHoraria = cursoDto.cargaHoraria,
                DisponibilidadeCurso = cursoDto.Disponibilidade,
                InstrutorID = cursoDto.InstrutorID
            };

            _repository.Adicionar(curso);
            return CursoParaDto.ConverterParaDto(curso);
        }

        public LerCursoDto Atualizar(int id, CriarCursoDto cursoDto)
        {
            Curso cursoBanco = _repository.ObterPorId(id);

            if(cursoBanco == null)
            {
                throw new DomainException("Curso não encontrado.");
            }

            cursoBanco.Nome = cursoDto.Nome;
            cursoBanco.CargaHoraria = cursoDto.cargaHoraria;
            cursoBanco.Descricao = cursoDto.Descricao;
            cursoBanco.DisponibilidadeCurso = cursoDto.Disponibilidade;
            cursoBanco.InstrutorID = cursoDto.InstrutorID;

            _repository.Atualizar(cursoBanco);
            return CursoParaDto.ConverterParaDto(cursoBanco);
        }

        public void Remover(int id)
        {
            Curso curso = _repository.ObterPorId(id);

            if(curso == null)
            {
                throw new DomainException("Curso não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
