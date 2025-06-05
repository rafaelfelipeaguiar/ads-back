using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class CorpoDoscenteService
    {
        private readonly ApplicationDbContext _context;

        public CorpoDoscenteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CorpoDoscente>> GetAll()
        {
            return await _context.CorpoDoscente.ToListAsync();
        }

        public async Task<CorpoDoscente?> GetById(int id)
        {
            return await _context.CorpoDoscente.FindAsync(id);
        }

        public async Task<CorpoDoscente> Create(CorpoDoscenteCreateDTO dto)
        {
            var corpo = new CorpoDocente
            {
                ServidorId = dto.ServidorId,
                Disciplina = dto.Disciplina
            };

            _context.CorpoDoscente.Add(corpo);
            await _context.SaveChangesAsync();
            return corpo;
        }

        public async Task<bool> Delete(int id)
        {
            var corpo = await _context.CorpoDoscente.FindAsync(id);
            if (corpo == null) return false;

            _context.CorpoDoscente.Remove(corpo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
