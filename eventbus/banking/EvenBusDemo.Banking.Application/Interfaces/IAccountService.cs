using EventBusDemo.Banking.Application.Models;
using EventBusDemo.Banking.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
