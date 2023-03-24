using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace NiceAPI.DataLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext appContext;
        private DbSet<TEntity> entities;

        public GenericRepository(AppDbContext context)
        {
            this.appContext = context;
            this.entities = this.appContext.Set<TEntity>();

        }
        public List<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity GetById(int entityId)
        {
            return entities.Find(entityId);
        }

        public void Insert(TEntity entity)
        {

            entities.Add(entity);
            appContext.SaveChanges();
        }

        public void Remove(int id)
        {
            
            TEntity entity = entities.Find(id);
            // deletes data from database permenantley
            entities.Remove(entity);
            appContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
            appContext.SaveChanges();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        
    }
}
