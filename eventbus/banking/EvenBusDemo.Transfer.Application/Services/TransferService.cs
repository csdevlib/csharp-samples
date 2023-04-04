
using BeyondNet.Product.Patterns.EventBusNet.Common.Bus;
using EventBusDemo.Transfer.Application.Interfaces;
using EventBusDemo.Transfer.Domain.Interfaces;
using EventBusDemo.Transfer.Domain.Models;
using System.Collections.Generic;

namespace EventBusDemo.Banking.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _repository;
        
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository repository, IEventBus bus)
        {
            _repository = repository;
            
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransfersLogs()
        {
            return _repository.GetTransfersLogs();
        }
    }
}
