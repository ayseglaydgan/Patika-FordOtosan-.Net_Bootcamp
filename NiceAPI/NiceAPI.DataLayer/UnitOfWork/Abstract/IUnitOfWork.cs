using System;


namespace NiceAPI.DataLayer
{
    public interface IUnitOfWork : IDisposable 
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }

        void Complete();
        void CompleteWithTransaction();
    }
}
