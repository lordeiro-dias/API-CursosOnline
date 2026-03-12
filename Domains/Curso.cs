using System;
using System.Collections.Generic;

namespace CursosOnline.Domains;

public partial class Curso
{
    public int CursoID { get; set; }

    public string? Nome { get; set; }

    public string? CargaHoraria { get; set; }

    public bool? DisponibilidadeCurso { get; set; }

    public string? Descricao { get; set; }

    public int? InstrutorID { get; set; }

    public virtual Instrutor? Instrutor { get; set; }

    public virtual ICollection<Matricula> Matricula { get; set; } = new List<Matricula>();
}
