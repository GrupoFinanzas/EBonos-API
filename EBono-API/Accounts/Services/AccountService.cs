using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Repositories;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Accounts.Domain.Services.Communication;
using EBono_API.Shared.Domain.Repositories;

namespace EBono_API.Accounts.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            var account = await _accountRepository.FindByIdAsync(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }

        public async Task<AccountResponse> RegisterAsync(Account account)
        {
            try
            {
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(account);
            }
            catch (Exception e)
            {
                return new AccountResponse($"An error occurred while registering account: {e.Message}");
            }
        }

        public async Task<AccountResponse> UpdateAsync(int id, Account account)
        {
            var existingAccount = await _accountRepository.FindByIdAsync(id);

            if (existingAccount == null) return new AccountResponse("Account not found");
            existingAccount.Name = account.Name;
            existingAccount.Email = account.Email;
            existingAccount.Password = account.Password;
            existingAccount.CreatedAt = account.CreatedAt;

            try
            {
                _accountRepository.Update(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception e)
            {
                return new AccountResponse($"An error occurred while updating account: {e.Message}");
            }
        }

        public async Task<AccountResponse> DeleteAsync(int id)
        {
            var existingAccount = await _accountRepository.FindByIdAsync(id);

            if (existingAccount == null) return new AccountResponse("Account not found");
            
            try
            {
                _accountRepository.Remove(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception e)
            {
                return new AccountResponse($"An error occurred while deleting account: {e.Message}");
            }
        }
    }
}