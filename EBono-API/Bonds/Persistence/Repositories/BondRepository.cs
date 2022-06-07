using System.Collections.Generic;
using System.Threading.Tasks;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Domain.Repositories;
using EBono_API.Shared.Persistence.Contexts;
using EBono_API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EBono_API.Bonds.Persistence.Repositories
{
    public class BondRepository : BaseRepository, IBondRepository
    {
        public BondRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Bond>> ListAsync()
        {
            return await _context.Bonds.ToListAsync();
        }

        public async Task AddAsync(Bond bond)
        {
            await _context.Bonds.AddAsync(bond);
        }

        public async Task<Bond> FindByIdAsync(int id)
        {
            return await _context.Bonds.FindAsync(id);
        }

        public void Update(Bond bond)
        {
            _context.Bonds.Update(bond);
        }

        public void Remove(Bond bond)
        {
            _context.Bonds.Remove(bond);
        }

        
    }
}