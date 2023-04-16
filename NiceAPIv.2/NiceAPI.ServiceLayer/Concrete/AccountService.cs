using AutoMapper;
using NiceAPI.BaseClass;
using NiceAPI.DataLayer;
using NiceAPI.DataLayer.Model;
using NiceAPI.DtoLayer.Dto;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.ServiceLayer.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.ServiceLayer.Concrete
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IGenericRepository<Account> genericRepository;
        private readonly IMapper mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Account> genericRepository) : base(unitOfWork, mapper, genericRepository)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public BaseResponse<AccountDto> GetByUsername(string username)
        {
            var account = genericRepository.Where(x => x.UserName == username).FirstOrDefault();
            var mapped = mapper.Map<Account, AccountDto>(account);
            return new BaseResponse<AccountDto>(mapped);
        }

        public static int GetIdFromToken(ClaimsPrincipal User)
        {
            var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return int.Parse(id);

        }

        public static string GetRoleFromToken(ClaimsPrincipal User)
        {
            var role = (User.Identity as ClaimsIdentity).FindFirst("Role").Value;
            return role;

        }
    }
}
