using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Accounts.Resources;
using EBono_API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EBono_API.Accounts.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<AccountResource>> GetAllAsync()
        {
            var accounts = await _accountService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<AccountResource> GetByIdAsync(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            var resource = _mapper.Map<Account, AccountResource>(account);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var account = _mapper.Map<SaveAccountResource, Account>(resource);

            var result = await _accountService.RegisterAsync(account);
            if (!result.Success) return BadRequest(result.Message);

            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);

            return Ok(accountResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var account = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.UpdateAsync(id, account);
            
            if (!result.Success) return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            
            return Ok(accountResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _accountService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);
            var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);
            
            return Ok(accountResource);
        }
    }
}