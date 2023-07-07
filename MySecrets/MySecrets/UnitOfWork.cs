using MySecrets.Interfaces;
using MySecrets.Repo;

namespace MySecrets
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ITajneRepository TajneRepository =>
                new TajneRepository(dc);

        public IKorisnikRepository KorisnikRepository => 
                new KorisnikRepository(dc);
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
