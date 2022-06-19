using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Domain.Services;
using EBono_API.Results.Resources;
using Microsoft.AspNetCore.Mvc;

namespace EBono_API.Bonds.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/bonds/{bondId}/results")]
    public class BondResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public BondResultController(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ResultResource> GetAllByBondIdAsync(int bondId)
        {
            var results = await _resultService.GetByBondIdAsync(bondId);
            var resources = _mapper.Map<Result, ResultResource>(results);
            return resources;
        }
    }
}