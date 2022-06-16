using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Domain.Services;
using EBono_API.Results.Resources;
using EBono_API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EBono_API.Results.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public ResultController(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ResultResource>> GetAllAsync()
        {
            var results = await _resultService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Result>, IEnumerable<ResultResource>>(results);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ResultResource> GetByIdAsync(int id)
        {
            var result = await _resultService.GetByIdAsync(id);
            var resource = _mapper.Map<Result, ResultResource>(result);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveResultResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var result = _mapper.Map<SaveResultResource, Result>(resource);
            var outcome = await _resultService.SaveAsync(result);
            if (!outcome.Success) return BadRequest(outcome.Message);

            var resultResource = _mapper.Map<Result, ResultResource>(outcome.Resource);
            return Ok(resultResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveResultResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var result = _mapper.Map<SaveResultResource, Result>(resource);
            var outcome = await _resultService.UpdateAsync(id, result);
            if (!outcome.Success) return BadRequest(outcome.Message);

            var resultResource = _mapper.Map<Result, ResultResource>(outcome.Resource);
            return Ok(resultResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var outcome = await _resultService.DeleteAsync(id);
            if (!outcome.Success) return BadRequest(outcome.Message);

            var resultResource = _mapper.Map<Result, ResultResource>(outcome.Resource);
            return Ok(resultResource);
        }
    }
}