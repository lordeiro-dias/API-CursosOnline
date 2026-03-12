using CursosOnline.Contexts;
using CursosOnline.Domains;
using CursosOnline.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursosOnline.Repositories
{
    public class InstrutorRepository : IInstrutorRepository
    {
        private readonly CursosOnlineContext _context;

        public InstrutorRepository(CursosOnlineContext context)
        {
            _context = context;
        }

        public List<Instrutor> Listar()
        {
            return _context.Instrutor.ToList();
        }

        public Instrutor? ObterPorId(int id)
        {
            return _context.Instrutor.Find(id);
        }

        public Instrutor? ObterPorEmail(string email)
        {
            return _context.Instrutor.FirstOrDefault(i => i.Email == email);
        }

        public bool EmailExiste(string email)
        {
            return _context.Instrutor.Any(i => i.Email == email);
        }

        public void Adicionar(Instrutor instrutor)
        {
            _context.Instrutor.Add(instrutor);
            _context.SaveChanges();
        }

        public void Atualizar(Instrutor instrutor)
        {
            Instrutor? instrutorBanco = _context.Instrutor.FirstOrDefault(i => i.InstrutorID == instrutor.InstrutorID);

            if(instrutorBanco == null)
            {
                return;
            }

            instrutorBanco.Nome = instrutor.Nome;
            instrutorBanco.Email = instrutor.Email;
            instrutorBanco.Senha = instrutor.Senha;
            instrutorBanco.AreaEspecializacao = instrutor.AreaEspecializacao;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Instrutor? instrutorBanco = _context.Instrutor.FirstOrDefault(i => i.InstrutorID == id);

            if(instrutorBanco == null)
            {
                return;
            }

            _context.Instrutor.Remove(instrutorBanco);
            _context.SaveChanges();
        }
    }
}
