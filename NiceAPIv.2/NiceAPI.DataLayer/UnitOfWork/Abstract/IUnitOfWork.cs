using NiceAPI.DataLayer.Model;
using System;


namespace NiceAPI.DataLayer
{
    public interface IUnitOfWork : IDisposable 
    {
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Account> AccountRepository { get; }

        
        void CompleteWithTransaction();
        void Complete();
    }
}
