using Microsoft.AspNetCore.Mvc;
using MySecrets.Models;

namespace MySecrets.Interfaces
{
    public interface ITajneRepository
    {
        void AddTajna(Tajne tajna);
        Task<IEnumerable<Tajne>> GetAllAsync();
        Task<IEnumerable<Tajne>> GetById(int id);
        Task<IEnumerable<Tajne>> GetTajneAsc(int page, int pageSize, int id);
        Task<IEnumerable<Tajne>> GetTajneDesc(int page, int pageSize, int id);
        Task<IEnumerable<Tajne>> SearchPost(int id, string ime);
        Task<IEnumerable<Tajne>> Page(int page, int pageSize, int id);

    }
}
