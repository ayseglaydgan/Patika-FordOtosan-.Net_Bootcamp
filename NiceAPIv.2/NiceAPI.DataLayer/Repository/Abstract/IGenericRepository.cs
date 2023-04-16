using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.DataLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int entityId);
        void Insert(TEntity entity);

        void Remove(TEntity entity);
        void Remove(int id);
        void Update(TEntity entity);

        List<TEntity> GetAll();

        List<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);
        //WHERE

        void Detach(TEntity entity);
    }
}
