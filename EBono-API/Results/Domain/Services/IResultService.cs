using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Domain.Services.Communication;

namespace EBono_API.Results.Domain.Services
{
    public interface IResultService
    {
        Task<IEnumerable<Result>> ListAsync();
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetByBondIdAsync(int bondId);
        Task<ResultResponse> SaveAsync(Result result);
        Task<ResultResponse> UpdateAsync(int id, Result result);
        Task<ResultResponse> DeleteAsync(int id);
    }
}