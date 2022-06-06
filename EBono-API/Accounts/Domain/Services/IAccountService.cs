using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Services.Communication;

namespace EBono_API.Accounts.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAsync();
        Task<Account> GetByIdAsync(int id);
        Task<AccountResponse> RegisterAsync(Account account);
        Task<AccountResponse> UpdateAsync(int id, Account account);
        Task<AccountResponse> DeleteAsync(int id);
    }
}