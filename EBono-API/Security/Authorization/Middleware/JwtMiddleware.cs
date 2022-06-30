using System.Linq;
using System.Threading.Tasks;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Security.Authorization.Handlers.Interfaces;
using EBono_API.Security.Authorization.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EBono_API.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAccountService accountService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = handler.ValidateToken(token);
            if (accountId != null)
            {
                context.Items["Account"] = await accountService.GetByIdAsync(accountId.Value);
            }

            await _next(context);
        }
    }
}