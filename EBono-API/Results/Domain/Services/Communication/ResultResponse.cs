using EBono_API.Results.Domain.Models;
using EBono_API.Shared.Domain.Services.Communication;

namespace EBono_API.Results.Domain.Services.Communication
{
    public class ResultResponse : BaseResponse<Result>
    {
        public ResultResponse(string message) : base(message)
        {
        }

        public ResultResponse(Result resource) : base(resource)
        {
        }
    }
}