using EventBusDemo.Transfer.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransfersLogs();
        void Add(TransferLog transferLog);
    }
}
