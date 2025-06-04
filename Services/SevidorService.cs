using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class ServidorService
    {
        private readonly ApplicationDbContext _context;

        public ServidorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servidor>> GetAll()
        {
            return await _context.Servidor.ToListAsync();
        }

        public async Task<Servidor?> GetById(int id)
        {
            return await _context.Servidor.FindAsync(id);
        }

        public async Task<Servidor> Create(ServidorCreateDTO dto)
        {
            var servidor = new Servidor
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Senha = dto.Senha,
                Tipo = dto.Tipo
            };

            _context.Servidor.Add(servidor);
            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<Servidor?> Update(int id, ServidorUpdateDTO dto)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null) return null;

            servidor.Nome = dto.Nome;
            servidor.Cpf = dto.Cpf;
            servidor.Email = dto.Email;
            servidor.Senha = dto.Senha;
            servidor.Tipo = dto.Tipo;

            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<bool> Delete(int id)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null) return false;

            _context.Servidor.Remove(servidor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
