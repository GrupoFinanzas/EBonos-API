using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Bonds.Domain.Models;

namespace EBono_API.Bonds.Domain.Repositories
{
    public interface IBondRepository
    {
        Task<IEnumerable<Bond>> ListAsync();
        Task<Bond> FindByIdAsync(int id);
        Task<IEnumerable<Bond>> FinByAccountId(int accountId);
        Task AddAsync(Bond bond);
        void Update(Bond bond);
        void Remove(Bond bond);
    }
}