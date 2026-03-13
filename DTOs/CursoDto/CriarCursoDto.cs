namespace CursosOnline.DTOs.CursoDto
{
    public class CriarCursoDto
    {
        public string Nome { get; set; } = null!;
        public string cargaHoraria { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public bool? Disponibilidade { get; set; }
        public int InstrutorID { get; set; }
    }
}
