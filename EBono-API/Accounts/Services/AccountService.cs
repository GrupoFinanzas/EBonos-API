using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBono_API.Accounts.Domain.Models;
using EBono_API.Accounts.Domain.Repositories;
using EBono_API.Accounts.Domain.Services;
using EBono_API.Security.Authorization.Handlers.Interfaces;
using EBono_API.Security.Domain.Services.Communication;
using EBono_API.Security.Exceptions;
using EBono_API.Shared.Domain.Repositories;

namespace EBono_API.Accounts.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var account = await _accountRepository.FindByEmailAsync(request.Email);

            if (account == null || request.Password != account.Password)
                throw new AppException("Username or password is incorrect");

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.Token = _jwtHandler.GenerateToken(account);
            return response;
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

        public async Task RegisterAsync(RegisterRequestAccount request)
        {
            if (_accountRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken");

            var account = _mapper.Map<Account>(request);
            account.Password = request.Password;

            try
            {
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error ocurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequestAccount request)
        {
            var account = GetById(id);
            
            
            if (_accountRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken");

            if (!string.IsNullOrEmpty(request.Email))
                account.Password = request.Password;

            try
            {
                _accountRepository.Update(account);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error ocurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var account = GetById(id);

            try
            {
                _accountRepository.Remove(account);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the account: {e.Message}");
            }
        }

        private Account GetById(int id)
        {
            var account = _accountRepository.FindById(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }
    }
}