namespace CursosOnline.DTOs.MatriculaDto
{
    public class LerMatriculaDto
    {
        public int MatriculaID { get; set; }
        public DateTime? DataMatricula { get; set; }
        public int? AlunoID { get; set; }
        public string? AlunoNome { get; set; }
        public int? CursoID { get; set; }
        public string? CursoNome { get; set; }


    }
}
