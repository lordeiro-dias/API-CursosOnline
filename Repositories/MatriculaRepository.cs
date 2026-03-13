using CursosOnline.Contexts;
using CursosOnline.Domains;
using CursosOnline.Interfaces;

namespace CursosOnline.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly CursosOnlineContext _context;

        public MatriculaRepository(CursosOnlineContext context)
        {
            _context = context;
        }

        public List<Matricula> Listar()
        {
            return _context.Matricula.ToList();
        }

        public Matricula ObterPorId(int id)
        {
            return _context.Matricula.Find(id);
        }

        public void Adicionar(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            _context.SaveChanges();
        }

        public void Atualizar(Matricula matricula)
        {
            Matricula? matriculaBanco = _context.Matricula.FirstOrDefault(m => m.MatriculaID == matricula.MatriculaID);

            if(matriculaBanco == null)
            {
                return;
            }

            matriculaBanco.DataMatricula = matricula.DataMatricula;
            matriculaBanco.CursoID = matricula.CursoID;
            matriculaBanco.AlunoID = matricula.AlunoID;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Matricula? matriculaBanco = _context.Matricula.FirstOrDefault(m => m.MatriculaID == id);

            if(matriculaBanco == null)
            {
                return; 
            }

            _context.Matricula.Remove(matriculaBanco);
            _context.SaveChanges();
        }
    }
}
