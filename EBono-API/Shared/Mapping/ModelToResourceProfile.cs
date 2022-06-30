using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Resources;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Resources;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Resources;
using EBono_API.Security.Domain.Services.Communication;

namespace EBono_API.Shared.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Account, AccountResource>();
            CreateMap<Bond, BondResource>();
            CreateMap<Result, ResultResource>();
            CreateMap<Account, AuthenticateResponse>();
        }
    }
}