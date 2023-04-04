using EventBusDemo.Transfer.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransfersLogs();
    }
}
