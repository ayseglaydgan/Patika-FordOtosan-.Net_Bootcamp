using AutoMapper;
using NiceAPI.DataLayer;
using NiceAPI.DataLayer.Model;
using NiceAPI.DtoLayer.Dto;

namespace NiceAPI.ServiceLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

        }

    }
}
