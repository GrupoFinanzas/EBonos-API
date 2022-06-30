using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Services.Communication;
using EBono_API.Security.Domain.Services.Communication;

namespace EBono_API.Accounts.Domain.Services
{
    public interface IAccountService
    {
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<Account>> ListAsync();
        Task<Account> GetByIdAsync(int id);
        public Task RegisterAsync(RegisterRequestAccount request);
        public Task UpdateAsync(int id, UpdateRequestAccount request);
        public Task DeleteAsync(int id);
    }
}