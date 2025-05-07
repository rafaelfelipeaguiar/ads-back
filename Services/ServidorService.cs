// Services/ServidorService.cs
using GestaoAcademica.Data;
using GestaoAcademica.DTOs;
using GestaoAcademica.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Services
{
    public class ServidorService : IServidorService
    {
        private readonly ApplicationDbContext _context;

        public ServidorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servidor>> GetAll()
        {
            return await _context.Servidores.ToListAsync();
        }

        public async Task<Servidor?> GetById(int id)
        {
            return await _context.Servidores.FindAsync(id);
        }

        public async Task<Servidor> Create(ServidorCreateDTO servidorDTO)
        {
            var servidor = new Servidor
            {
                Nome = servidorDTO.Nome,
                Cpf = servidorDTO.Cpf,
                Email = servidorDTO.Email,
                Senha = servidorDTO.Senha,
                Tipo = servidorDTO.Tipo,
                CorpoDocente = await ValidateCorpoDocente(servidorDTO.FkIdCorpoDocente)
            };

            _context.Servidores.Add(servidor);
            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<Servidor?> Update(int id, ServidorUpdateDTO servidorDTO)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null) return null;

            // Atualizações
            if (!string.IsNullOrEmpty(servidorDTO.Nome))
                servidor.Nome = servidorDTO.Nome;

            if (!string.IsNullOrEmpty(servidorDTO.Cpf))
                servidor.Cpf = servidorDTO.Cpf;

            // ... (demais atualizações)

            servidor.CorpoDocente = await ValidateCorpoDocente(servidorDTO.FkIdCorpoDocente);
            
            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<bool> Delete(int id)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null) return false;

            _context.Servidores.Remove(servidor);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<CorpoDocente?> ValidateCorpoDocente(int? id)
        {
            if (!id.HasValue) return null;
            
            var corpoDocente = await _context.CorposDocente
                .FindAsync(id.Value);
            
            if (corpoDocente == null) 
                throw new KeyNotFoundException("Corpo docente não encontrado");
            
            return corpoDocente;
        }
    }
}