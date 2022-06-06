using EBono_API.Accounts.Domain.Models;
using EBono_API.Shared.Domain.Services.Communication;

namespace EBono_API.Accounts.Domain.Services.Communication
{
    public class AccountResponse : BaseResponse<Account>
    {
        public AccountResponse(string message) : base(message)
        {
        }

        public AccountResponse(Account resource) : base(resource)
        {
        }
    }
}