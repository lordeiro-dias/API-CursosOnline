using CursosOnline.Domains;
using CursosOnline.DTOs.CursoDto;

namespace CursosOnline.Applications.Conversoes
{
    public class CursoParaDto
    {
        public static LerCursoDto ConverterParaDto(Curso curso)
        {
            return new LerCursoDto
            {
                CursoID = curso.CursoID,
                Nome = curso.Nome,
                cargaHoraria = curso.CargaHoraria,
                Descricao = curso.Descricao,
                Disponibilidade = curso.DisponibilidadeCurso,
                InstrutorID = curso.InstrutorID,
                InstrutorNome = curso.Instrutor?.Nome
            };
        }
    }
}
