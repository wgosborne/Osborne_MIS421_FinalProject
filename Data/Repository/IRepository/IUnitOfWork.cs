namespace _521Final.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }

        void Save();
    }
}
