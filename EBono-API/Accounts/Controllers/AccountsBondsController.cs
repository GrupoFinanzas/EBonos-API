using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Domain.Services;
using EBono_API.Bonds.Resources;
using Microsoft.AspNetCore.Mvc;

namespace EBono_API.Accounts.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/accounts/{accountId}/bonds")]
    public class AccountsBondsController : ControllerBase
    {
        private readonly IBondService _bondService;
        private readonly IMapper _mapper;

        public AccountsBondsController(IBondService bondService, IMapper mapper)
        {
            _bondService = bondService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BondResource>> GetAllByAccountIdAsync(int accountId)
        {
            var bonds = await _bondService.ListByAccountIdAsync(accountId);
            var resources = _mapper.Map<IEnumerable<Bond>, IEnumerable<BondResource>>(bonds);
            return resources;
        }
    }
}