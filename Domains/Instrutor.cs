using System;
using System.Collections.Generic;

namespace CursosOnline.Domains;

public partial class Instrutor
{
    public int InstrutorID { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public byte[]? Senha { get; set; }

    public string? AreaEspecializacao { get; set; }

    public virtual ICollection<Curso> Curso { get; set; } = new List<Curso>();
}
