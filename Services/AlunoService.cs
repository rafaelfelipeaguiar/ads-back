using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class AlunoService
    {
        private readonly ApplicationDbContext _context;

        public AlunoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAll()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno?> GetById(int id)
        {
            return await _context.Aluno.FindAsync(id);
        }

        public async Task<Aluno> Create(AlunoCreateDTO dto)
        {
            var aluno = new Aluno
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Matricula = dto.Matricula
            };

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno?> Update(int id, AlunoUpdateDTO dto)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null) return null;

            aluno.Nome = dto.Nome;
            aluno.Cpf = dto.Cpf;
            aluno.Email = dto.Email;
            aluno.Telefone = dto.Telefone;
            aluno.Matricula = dto.Matricula;

            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<bool> Delete(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null) return false;

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
