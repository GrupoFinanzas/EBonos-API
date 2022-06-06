using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Resources;

namespace EBono_API.Shared.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccountResource, Account>();
        }
    }
}