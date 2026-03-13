using CursosOnline.Contexts;
using CursosOnline.Domains;
using CursosOnline.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Security;

namespace CursosOnline.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursosOnlineContext _context;

        public CursoRepository(CursosOnlineContext context)
        {
            _context = context;
        }

        public List<Curso> Listar()
        {
            List<Curso> cursos = _context.Curso.Include(c => c.Instrutor).ToList();

            return cursos;
        }

        public Curso ObterPorId(int id)
        {
            Curso? curso = _context.Curso.Include(c => c.Instrutor).FirstOrDefault(c => c.CursoID == id);

            return curso;
        }

        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
            _context.SaveChanges();
        }

        public void Atualizar(Curso curso)
        {
            Curso? cursoBanco = _context.Curso.Include(c => c.Instrutor).FirstOrDefault(c => c.CursoID == curso.CursoID);

            if(cursoBanco == null)
            {
                return;
            }

            cursoBanco.Nome = curso.Nome;
            cursoBanco.CargaHoraria = curso.CargaHoraria;
            cursoBanco.Descricao = curso.Descricao;
            cursoBanco.DisponibilidadeCurso = curso.DisponibilidadeCurso;
            cursoBanco.InstrutorID = curso.InstrutorID;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Curso? curso = _context.Curso.FirstOrDefault(c => c.CursoID == id);

            if(curso == null)
            {
                return; 
            }

            _context.Remove(curso);
            _context.SaveChanges();
        }
    }
}
