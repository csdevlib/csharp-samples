using EventBusDemo.Banking.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
