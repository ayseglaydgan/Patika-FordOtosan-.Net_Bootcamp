using NiceAPI.DataLayer;
using NiceAPI.DtoLayer.Dto;
using NiceAPI.ServiceLayer.Base;
using NiceAPI.ServiceLayer.Base.Concrete;
using AutoMapper;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.BaseClass;
using System;
using System.Collections.Generic;

namespace NiceAPI.ServiceLayer.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IAccountService accountService;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
        {
            this.accountService = accountService;
        }

        /*public override BaseResponse<bool> Insert(PersonDto insertResource)
          {
            DateTime birthDate = insertResource.DateOfBirth;
            DateTime now = DateTime.Now;
            TimeSpan age = now - birthDate;
            int years = (int)(age.TotalDays / 365.25);

            if (years < 18)
            {
                return new BaseResponse<bool>("DateOfBirth was incorrect");
            }

            var response = accountService.GetByUsername(insertResource.Email);
            if (!response.Success)
            {
                return new BaseResponse<bool>(response.Message);
            }

            AccountDto account = response.Response;

            return base.Insert(insertResource);
        }*/
    }
}
