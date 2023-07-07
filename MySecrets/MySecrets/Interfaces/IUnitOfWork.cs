namespace MySecrets.Interfaces
{
    public interface IUnitOfWork
    {
        ITajneRepository TajneRepository { get; }
        IKorisnikRepository KorisnikRepository { get; }
        Task<bool> SaveAsync();
    }
}
