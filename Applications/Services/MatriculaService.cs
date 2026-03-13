using CursosOnline.Domains;
using CursosOnline.DTOs.InstrutorDto;
using CursosOnline.DTOs.MatriculaDto;
using CursosOnline.Excpetions;
using CursosOnline.Interfaces;

namespace CursosOnline.Applications.Services
{
    public class MatriculaService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public static LerMatriculaDto LerDto(Matricula matricula)
        {
            LerMatriculaDto lerMatricula = new LerMatriculaDto
            {
                MatriculaID = matricula.MatriculaID,
                DataMatricula = matricula.DataMatricula,
                AlunoID = matricula.AlunoID,
                AlunoNome = matricula.Aluno?.Nome,
                CursoID = matricula.CursoID,
                CursoNome = matricula.Curso?.Nome
            };

            return lerMatricula;
        }

        public List<LerMatriculaDto> Listar()
        {
            List<Matricula> matriculas = _repository.Listar();

            List<LerMatriculaDto> matriculasDto = matriculas.Select(matriculasBanco => LerDto(matriculasBanco)).ToList();
            return matriculasDto;
        }

        public LerMatriculaDto ObterPorId(int id)
        {
            Matricula? matricula = _repository.ObterPorId(id);

            if (matricula == null)
            {
                throw new DomainException("Matrícula não existe.");
            }

            return LerDto(matricula);
        }

        public LerMatriculaDto Adicionar(CriarMatriculaDto matriculaDto)
        { 

            Matricula matricula = new Matricula
            {
                DataMatricula = matriculaDto.DataMatricula,
                AlunoID = matriculaDto.AlunoID,
                CursoID = matriculaDto.CursoID
            };

            _repository.Adicionar(matricula);
            return LerDto(matricula);
        }

        public LerMatriculaDto Atualizar(int id, CriarMatriculaDto matriculaDto)
        {
            Matricula matriculaBanco = _repository.ObterPorId(id);

            if (matriculaBanco == null)
            {
                throw new DomainException("Matrícula não encontrado");
            }

            matriculaBanco.DataMatricula = matriculaDto.DataMatricula;
            matriculaBanco.AlunoID = matriculaDto.AlunoID;
            matriculaBanco.CursoID = matriculaDto.CursoID;

            _repository.Atualizar(matriculaBanco);

            return LerDto(matriculaBanco);
        }

        public void Remover(int id)
        {
            Matricula matricula = _repository.ObterPorId(id);

            if (matricula == null)
            {
                throw new DomainException("Instrutor não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
