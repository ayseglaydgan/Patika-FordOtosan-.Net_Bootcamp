using NiceAPI.BaseClass;
using NiceAPI.DataLayer.Model;
using NiceAPI.DtoLayer.Dto;
using NiceAPI.ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.ServiceLayer.Abstract
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        BaseResponse<AccountDto> GetByUsername(string username);
    }
}
