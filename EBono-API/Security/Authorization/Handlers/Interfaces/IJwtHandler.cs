using EBono_API.Accounts.Domain.Models;

namespace EBono_API.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(Account account);
        public int? ValidateToken(string token);
    }
}