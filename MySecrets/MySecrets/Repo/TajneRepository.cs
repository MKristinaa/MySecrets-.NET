using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySecrets.Interfaces;
using MySecrets.Models;

namespace MySecrets.Repo
{
    public class TajneRepository : ITajneRepository
    {
        private readonly DataContext dc;

        public TajneRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddTajna(Tajne tajna)
        {
            dc.Tajne!.AddAsync(tajna);
        }


        public async Task<IEnumerable<Tajne>> GetAllAsync()
        {
            
            return await dc.Tajne!.ToListAsync();
        }

        public async Task<IEnumerable<Tajne>> GetById(int id)
        {

            return await dc.Tajne!.Where(s=> s.IdKorisnika == id).ToListAsync();
        }

        public async Task<IEnumerable<Tajne>> GetTajneAsc(int page, int pageSize, int id)
        {
            return await dc.Tajne!.Where(t => t.IdKorisnika == id).OrderBy(t => t.Id).ThenBy(t => t.Type).ToListAsync();

        }

        public async Task<IEnumerable<Tajne>> GetTajneDesc(int page, int pageSize, int id)
        {
            int totalNumber = page * pageSize - pageSize;
            var sortedTajne = await dc.Tajne!.Where(t => t.IdKorisnika == id).OrderByDescending(t => t.Id).ThenByDescending(t => t.Type).Skip(totalNumber).Take(pageSize).ToListAsync();
            return sortedTajne;
        }


        public async Task<IEnumerable<Tajne>> SearchPost(int id, string ime)
        {
            ime = ime.ToLower();
            return await dc.Tajne!.Where(t => (t.Type!.ToLower().Contains(ime)
                                             || t.URL!.ToLower().Contains(ime)
                                             || t.Username!.ToLower().Contains(ime)
                                             || t.Password!.ToLower().Contains(ime))
                                             && t.IdKorisnika == id).ToListAsync();
        }

        public async Task<IEnumerable<Tajne>> Page(int page, int pageSize, int id)
        {
            int totalNumber = page * pageSize - pageSize;

            var t = await dc.Tajne!.Where(s => s.IdKorisnika == id).Skip(totalNumber).Take(pageSize).ToListAsync();
            return t;
        }
    }
}
