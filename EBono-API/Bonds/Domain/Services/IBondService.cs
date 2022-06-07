using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Domain.Services.Communication;

namespace EBono_API.Bonds.Domain.Services
{
    public interface IBondService
    {
        Task<IEnumerable<Bond>> ListAsync();
        Task<Bond> GetByIdAsync(int id);
        Task<BondResponse> SaveAsync(Bond bond);
        Task<BondResponse> UpdateAsync(int id, Bond bond);
        Task<BondResponse> DeleteAsync(int id);
    }
}