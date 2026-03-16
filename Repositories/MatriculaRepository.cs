using CursosOnline.Contexts;
using CursosOnline.Domains;
using CursosOnline.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            List<Matricula> matriculas = _context.Matricula.Include(m => m.Aluno).Include(m => m.Curso).ToList();

            return matriculas;
        }

        public Matricula ObterPorId(int id)
        {
            Matricula? matricula = _context.Matricula.Include(m => m.Aluno).Include(m => m.Curso).FirstOrDefault(m => m.MatriculaID == id);

            return matricula;
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
