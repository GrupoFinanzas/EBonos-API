using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Resources;

namespace EBono_API.Shared.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Account, AccountResource>();
        }
    }
}