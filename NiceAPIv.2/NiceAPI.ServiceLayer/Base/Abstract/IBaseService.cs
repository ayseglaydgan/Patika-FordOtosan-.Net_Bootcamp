using NiceAPI.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.ServiceLayer.Base
{
    public interface IBaseService<Dto, TEntity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<List<Dto>> GetAll();
        BaseResponse<bool> Insert(Dto insertResource);
        BaseResponse<bool> Update(int id, Dto updateResource);
        BaseResponse<bool> Remove(int id);
        BaseResponse<List<Dto>> Where(Expression<Func<TEntity, bool>> where);
    }
}
