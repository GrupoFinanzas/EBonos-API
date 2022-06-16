using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Resources;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Resources;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Resources;

namespace EBono_API.Shared.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveBondResource, Bond>();
            CreateMap<SaveResultResource, Result>();
        }
    }
}