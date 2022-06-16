using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Results.Domain.Models;

namespace EBono_API.Results.Domain.Repositories
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> ListAsync();
        Task<Result> FindByIdAsync(int id);
        Task AddAsync(Result result);
        void Update(Result result);
        void Remove(Result result);
    }
}