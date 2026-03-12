using CursosOnline.Domains;
using CursosOnline.DTOs.InstrutorDto;
using CursosOnline.Excpetions;
using CursosOnline.Interfaces;
using CursosOnline.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace CursosOnline.Applications.Services
{
    public class InstrutorService
    {
        private readonly IInstrutorRepository _repository;

        public InstrutorService(IInstrutorRepository repository)
        {
            _repository = repository;
        }

        private static LerInstrutorDto LerDto(Instrutor instrutor)
        {
            LerInstrutorDto lerInstrutor = new LerInstrutorDto
            {
                InstrutorID = instrutor.InstrutorID,
                Nome = instrutor.Nome,
                Email = instrutor.Email,
                AreaEspecializacao = instrutor.AreaEspecializacao
            };

            return lerInstrutor;
        }

        public List<LerInstrutorDto> Listar()
        {
            List<Instrutor> instrutors = _repository.Listar();

            List<LerInstrutorDto> instrutorsDto = instrutors.Select(instrutorBanco => LerDto(instrutorBanco)).ToList();
            return instrutorsDto;
        }

        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new DomainException("E-mail inválido");
            }
        }

        private static byte[] HashSenha(string senha)
        {
            if(string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("Senha é obrigatória");
            }

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public LerInstrutorDto ObterPorId(int id)
        {
            Instrutor? instrutor = _repository.ObterPorId(id);

            if(instrutor == null)
            {
                throw new DomainException("Instrutor não existe.");
            }

            return LerDto(instrutor);
        }

        public LerInstrutorDto ObterPorEmail(string email)
        {
            Instrutor? instrutor = _repository.ObterPorEmail(email);

            if(instrutor == null)
            {
                throw new DomainException("Instrutor não existe");
            }

            return LerDto(instrutor);
        }

        public LerInstrutorDto Adicionar(CriarInstrutorDto instrutorDto)
        {
            ValidarEmail(instrutorDto.Email);

            if(_repository.EmailExiste(instrutorDto.Email))
            {
                throw new DomainException("Já existe um instrutor com esse e-mail.");
            }

            Instrutor instrutor = new Instrutor
            {
                Nome = instrutorDto.Nome,
                Email = instrutorDto.Email,
                Senha = HashSenha(instrutorDto.Senha),
                AreaEspecializacao = instrutorDto.AreaEspecializacao
            };

            _repository.Adicionar(instrutor);
            return LerDto(instrutor);
        }

        public LerInstrutorDto Atualizar(int id, CriarInstrutorDto instrutorDto)
        {
            Instrutor instrutorBanco = _repository.ObterPorId(id);

            if(instrutorBanco == null)
            {
                throw new DomainException("Instrutor não encontrado");
            }

            ValidarEmail(instrutorDto.Email);

            Instrutor instrutorComMesmoEmail = _repository.ObterPorEmail(instrutorDto.Email);

            if(instrutorComMesmoEmail != null && instrutorComMesmoEmail.InstrutorID != id)
            {
                throw new DomainException("Já existe um instrutor com esse e-mail");
            }

            instrutorBanco.Nome = instrutorDto.Nome;
            instrutorBanco.Email = instrutorDto.Email;
            instrutorBanco.Senha = HashSenha(instrutorDto.Senha);
            instrutorBanco.AreaEspecializacao = instrutorDto.AreaEspecializacao;

            _repository.Atualizar(instrutorBanco);

            return LerDto(instrutorBanco);
        }

        public void Remover(int id)
        {
            Instrutor instrutor = _repository.ObterPorId(id);

            if(instrutor == null)
            {
                throw new DomainException("Instrutor não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
