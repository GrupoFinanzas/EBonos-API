using EBono_API.Bonds.Domain.Models;
using EBono_API.Shared.Domain.Services.Communication;

namespace EBono_API.Bonds.Domain.Services.Communication
{
    public class BondResponse : BaseResponse<Bond>
    {
        public BondResponse(string message) : base(message)
        {
        }

        public BondResponse(Bond resource) : base(resource)
        {
        }
    }
}