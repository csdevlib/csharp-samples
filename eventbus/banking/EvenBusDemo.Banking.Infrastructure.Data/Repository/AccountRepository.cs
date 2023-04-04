using EventBusDemo.Banking.Domain.Interfaces;
using EventBusDemo.Banking.Domain.Models;
using EventBusDemo.Banking.Infrastructure.Data.Context;
using System.Collections.Generic;

namespace EventBusDemo.Banking.Infrastructure.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _dbContext;

        public AccountRepository(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _dbContext.Accounts;
        }
    }
}
