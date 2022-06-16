using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Domain.Repositories;
using EBono_API.Shared.Persistence.Contexts;
using EBono_API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EBono_API.Results.Persistence.Repositories
{
    public class ResultRepository : BaseRepository, IResultRepository
    {
        public ResultRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Result>> ListAsync()
        {
            return await _context.Results.ToListAsync();
        }

        public async Task AddAsync(Result result)
        {
            await _context.Results.AddAsync(result);
        }

        public async Task<Result> FindByIdAsync(int id)
        {
            return await _context.Results.FindAsync(id);
        }

        public void Update(Result result)
        {
            _context.Results.Update(result);
        }

        public void Remove(Result result)
        {
            _context.Results.Remove(result);
        }
    }
}