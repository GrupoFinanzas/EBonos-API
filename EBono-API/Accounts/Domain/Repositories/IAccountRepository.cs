using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Accounts.Domain.Models;

namespace EBono_API.Accounts.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> ListAsync();
        Task AddAsync(Account account);
        Task<Account> FindByIdAsync(int id);
        void Update(Account account);
        void Remove(Account account);
    }
}