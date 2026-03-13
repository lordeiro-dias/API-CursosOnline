using CursosOnline.Domains;

namespace CursosOnline.Interfaces
{
    public interface IMatriculaRepository
    {
        List<Matricula> Listar();
        Matricula? ObterPorId(int id);
        void Adicionar(Matricula matricula);
        void Atualizar(Matricula matricula);
        void Remover(int id);
    }
}
