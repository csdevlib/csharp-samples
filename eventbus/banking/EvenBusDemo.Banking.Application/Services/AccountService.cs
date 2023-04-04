using EvenBusDemo.Infrastructure.EventBus.Common.Bus;
using EventBusDemo.Banking.Application.Interfaces;
using EventBusDemo.Banking.Application.Models;
using EventBusDemo.Banking.Domain.Commands;
using EventBusDemo.Banking.Domain.Interfaces;
using EventBusDemo.Banking.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository repository, IEventBus bus)
        {
            _repository = repository;
            
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.Amount);

            _bus.SendCommand(createTransferCommand);
        }
    }
}
