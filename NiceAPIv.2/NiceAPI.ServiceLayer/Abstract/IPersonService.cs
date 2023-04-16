using NiceAPI.BaseClass;
using NiceAPI.DataLayer;
using NiceAPI.DtoLayer.Dto;
using NiceAPI.ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NiceAPI.ServiceLayer.Abstract
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
        
    }
}
