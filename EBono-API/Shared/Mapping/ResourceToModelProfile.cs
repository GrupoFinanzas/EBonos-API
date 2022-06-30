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
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveBondResource, Bond>();
            CreateMap<SaveResultResource, Result>();
            CreateMap<RegisterRequestAccount, Account>();
            CreateMap<UpdateRequestAccount, Account>()
                .ForAllMembers(options => options.Condition(
                    (source, target,property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string) property))
                            return false;
                        return true;
                    }));
        }
    }
}