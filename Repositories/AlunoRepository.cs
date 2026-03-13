using CursosOnline.Contexts;
using CursosOnline.Domains;
using CursosOnline.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Owin.Security;

namespace CursosOnline.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CursosOnlineContext _context;

        public AlunoRepository(CursosOnlineContext context)
        {
            _context = context;
        }

        public List<Aluno> Listar()
        {
            return _context.Aluno.ToList();
        }

        public Aluno? ObterPorId(int id)
        {
            return _context.Aluno.Find(id);
        }

        public Aluno? ObterPorEmail(string email)
        {
            return _context.Aluno.FirstOrDefault(a => a.Email == email);
        }

        public bool EmailExiste(string email)
        {
            return _context.Aluno.Any(a => a.Email == email);
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
        }

         public void Atualizar(Aluno aluno)
        {
            Aluno? alunoBanco = _context.Aluno.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);

            if(alunoBanco == null)
            {
                return;
            }

            alunoBanco.Nome = aluno.Nome;
            alunoBanco.Email = aluno.Email;
            alunoBanco.Senha = aluno.Senha;
            alunoBanco.StatusAluno = aluno.StatusAluno;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Aluno? alunoBanco = _context.Aluno.FirstOrDefault(a => a.AlunoID == id);

            if(alunoBanco == null)
            {
                return; 
            }

            _context.Aluno.Remove(alunoBanco);
            _context.SaveChanges();
        }
    }
}
