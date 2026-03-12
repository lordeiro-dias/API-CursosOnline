using System;
using System.Collections.Generic;

namespace CursosOnline.Domains;

public partial class Matricula
{
    public int MatriculaID { get; set; }

    public DateTime? DataMatricula { get; set; }

    public int? AlunoID { get; set; }

    public int? CursoID { get; set; }

    public virtual Aluno? Aluno { get; set; }

    public virtual Curso? Curso { get; set; }
}
