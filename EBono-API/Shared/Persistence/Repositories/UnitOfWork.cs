using System.Threading.Tasks;
using EBono_API.Shared.Domain.Repositories;
using EBono_API.Shared.Persistence.Contexts;

namespace EBono_API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}