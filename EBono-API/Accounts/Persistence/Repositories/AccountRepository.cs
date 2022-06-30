using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Repositories;
using EBono_API.Shared.Persistence.Contexts;
using EBono_API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EBono_API.Accounts.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> FindByEmailAsync(string email)
        {
            return await _context.Accounts.SingleOrDefaultAsync(p => p.Email == email);
        }

        public bool ExistByEmail(string email)
        {
            return _context.Accounts.Any(p => p.Email == email);
        }

        public Account FindById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public void Remove(Account account)
        {
            _context.Accounts.Remove(account);
        }
    }
}