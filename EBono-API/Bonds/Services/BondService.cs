using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Accounts.Domain.Repositories;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BondService(IBondRepository bondRepository, IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository)
        {
            _bondRepository = bondRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountRepository = accountRepository;
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

        public async Task<IEnumerable<Bond>> ListByAccountIdAsync(int accountId)
        {
            var existingAccount = _accountRepository.FindByIdAsync(accountId);
            if (existingAccount.Result == null) throw new KeyNotFoundException("Invalid Account ID");
            
            return await _bondRepository.FinByAccountId(accountId);
        }

        public async Task<BondResponse> SaveAsync(Bond bond)
        {
            var existingAccount = _accountRepository.FindByIdAsync(bond.AccountId);

            if (existingAccount.Result == null) return new BondResponse("Invalid Account ID");
            
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
        
        public async Task<BondResponse> UpdateAsync(int id, Bond bond)
        {
            var existingBond = await _bondRepository.FindByIdAsync(id);

            if (existingBond == null) return new BondResponse("Bond not found");
            
            var existingAccount = _accountRepository.FindByIdAsync(bond.AccountId);

            if (existingAccount.Result == null) return new BondResponse("Invalid Account");
            existingBond.NominalValue = bond.NominalValue;
            existingBond.Rate = bond.Rate;
            existingBond.RateType = bond.RateType;
            existingBond.ExpireDate = bond.ExpireDate;
            existingBond.ExpirationType = bond.ExpirationType;

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