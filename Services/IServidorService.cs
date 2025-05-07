using GestaoAcademica.DTOs;

namespace GestaoAcademica.Services
{
    public interface IServidorService
    {
        Task<IEnumerable<Servidor>> GetAll();
        Task<Servidor?> GetById(int id);
        Task<Servidor> Create(ServidorCreateDTO servidorDTO);
        Task<Servidor?> Update(int id, ServidorUpdateDTO servidorDTO);
        Task<bool> Delete(int id);
    }
}