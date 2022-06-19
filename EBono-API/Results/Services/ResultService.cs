using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Bonds.Domain.Repositories;
using EBono_API.Results.Domain.Models;
using EBono_API.Results.Domain.Repositories;
using EBono_API.Results.Domain.Services;
using EBono_API.Results.Domain.Services.Communication;
using EBono_API.Shared.Domain.Repositories;

namespace EBono_API.Results.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IBondRepository _bondRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResultService(IResultRepository resultRepository, IUnitOfWork unitOfWork, IMapper mapper, IBondRepository bondRepository)
        {
            _resultRepository = resultRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bondRepository = bondRepository;
        }

        public async Task<IEnumerable<Result>> ListAsync()
        {
            return await _resultRepository.ListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var result = await _resultRepository.FindByIdAsync(id);
            if (result == null) throw new KeyNotFoundException("Result not found");
            return result;
        }

        public async Task<Result> GetByBondIdAsync(int bondId)
        {
            var existingBond = _bondRepository.FindByIdAsync(bondId);
            if (existingBond.Result == null) throw new KeyNotFoundException("Invalid Bond Id");
            
            return await _resultRepository.FindByBondIdAsync(bondId);
        }

        public async Task<ResultResponse> SaveAsync(Result result)
        {
            try
            {
                await _resultRepository.AddAsync(result);
                await _unitOfWork.CompleteAsync();

                return new ResultResponse(result);
            }
            catch (Exception e)
            {
                return new ResultResponse($"An error occurred while registering result: {e.Message}");
            }
        }

        public async Task<ResultResponse> UpdateAsync(int id, Result result)
        {
            var existingResult = await _resultRepository.FindByIdAsync(id);
            
            if (existingResult == null) throw new KeyNotFoundException("Result not found");
            existingResult.Tir = result.Tir;
            existingResult.TirType = result.TirType;
            existingResult.Van = result.Van;
            existingResult.Time = result.Time;
            existingResult.TimeType = result.TimeType;
            existingResult.Duration = result.Duration;
            existingResult.ModDuration = result.ModDuration;
            existingResult.Convexity = result.Convexity;

            try
            { 
                _resultRepository.Update(existingResult);
                await _unitOfWork.CompleteAsync();

                return new ResultResponse(existingResult);
            }
            catch (Exception e)
            {
                return new ResultResponse($"An error occurred while updating result: {e.Message}");
            }
        }

        public async Task<ResultResponse> DeleteAsync(int id)
        {
            var existingResult = await _resultRepository.FindByIdAsync(id);
            
            if (existingResult == null) throw new KeyNotFoundException("Result not found");
            
            try
            { 
                _resultRepository.Remove(existingResult);
                await _unitOfWork.CompleteAsync();

                return new ResultResponse(existingResult);
            }
            catch (Exception e)
            {
                return new ResultResponse($"An error occurred while deleting result: {e.Message}");
            }
        }
    }
}