using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Bonds.Domain.Models;
using EBono_API.Bonds.Domain.Repositories;
using EBono_API.Bonds.Domain.Services;
using EBono_API.Bonds.Domain.Services.Communication;
using EBono_API.Shared.Domain.Repositories;

namespace EBono_API.Bonds.Services
{
    public class BondService : IBondService
    {
        private readonly IBondRepository _bondRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BondService(IBondRepository bondRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bondRepository = bondRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Bond>> ListAsync()
        {
            return await _bondRepository.ListAsync();
        }

        public async Task<Bond> GetByIdAsync(int id)
        {
            var bond = await _bondRepository.FindByIdAsync(id);
            if (bond == null) throw new KeyNotFoundException("Bond not found");
            return bond;
        }

        public async Task<BondResponse> SaveAsync(Bond bond)
        {
            try
            {
                await _bondRepository.AddAsync(bond);
                await _unitOfWork.CompleteAsync();

                return new BondResponse(bond);
            }
            catch (Exception e)
            {
                return new BondResponse($"An error occurred while registering bond: {e.Message}");
            }
        }

        // TODO: mejorar funcion update. Hacer que solo pida estos 4 valores
        public async Task<BondResponse> UpdateAsync(int id, Bond bond)
        {
            var existingBond = await _bondRepository.FindByIdAsync(id);

            if (existingBond == null) return new BondResponse("Bond not found");
            existingBond.CurrencyType = bond.CurrencyType;
            existingBond.NominalValue = bond.NominalValue;
            existingBond.Rate = bond.Rate;
            existingBond.RateType = bond.RateType;

            try
            {
                _bondRepository.Update(existingBond);
                await _unitOfWork.CompleteAsync();

                return new BondResponse(existingBond);
            }
            catch (Exception e)
            {
                return new BondResponse($"An error occurred while updating bond: {e.Message}");
            }
        }

        public async Task<BondResponse> DeleteAsync(int id)
        {
            var existingBond = await _bondRepository.FindByIdAsync(id);

            if (existingBond == null) return new BondResponse("Bond not found");
            
            try
            {
                _bondRepository.Remove(existingBond);
                await _unitOfWork.CompleteAsync();

                return new BondResponse(existingBond);
            }
            catch (Exception e)
            {
                return new BondResponse($"An error occurred while deleting bond: {e.Message}");
            }
        }
    }
}