using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Accounts.Resources;
using EBono_API.Security.Authorization.Attributes;
using EBono_API.Security.Domain.Services.Communication;
using EBono_API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EBono_API.Accounts.Controllers
{
    [Produces("application/json")]
    [AuthorizeAccount]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("/auth/sign-in/account")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _accountService.Authenticate(request);
            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("/auth/sign-up/account")]
        public async Task<IActionResult> Register(RegisterRequestAccount request)
        {
            await _accountService.RegisterAsync(request);
            return Ok(new {message = "Registration successful"});
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var accounts = await _accountService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            var resource = _mapper.Map<Account, AccountResource>(account);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateRequestAccount request)
        {
            await _accountService.UpdateAsync(id, request);
            return Ok(new {message = "User updated successfully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok(new {message = "User deleted successfully"});
        }
    }
}