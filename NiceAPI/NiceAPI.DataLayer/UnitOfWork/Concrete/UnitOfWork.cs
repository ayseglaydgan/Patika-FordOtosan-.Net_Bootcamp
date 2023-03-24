using System;


namespace NiceAPI.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appContext;
        private bool disposed;
        public IGenericRepository<Account> AccountRepository { get; private set; }

        public IGenericRepository<Person> PersonRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            appContext = context;
            AccountRepository = new GenericRepository<Account>(context);
            PersonRepository = new GenericRepository<Person>(context);
        }

        //IT MUST BE SAVE TO SEEN IN DB 
        public void CompleteWithTransaction()
        {
            using(var dbContextTransaction = appContext.Database.BeginTransaction())
            {
                try
                {
                    appContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch(Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            
        }

        public void Complete()
        {
            appContext.SaveChanges();
        }

        // Its all about garbage collector
        // Singleton veya scope olarak dependency injection ile projeye 1 kere inject et bitti
        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            { 
                if (disposing)
                {
                    appContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
