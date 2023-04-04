
using EventBusDemo.Transfer.Domain.Interfaces;
using EventBusDemo.Transfer.Domain.Models;
using EventBusDemo.Transfer.Infrastructure.Data.Context;
using System.Collections.Generic;

namespace EventBusDemo.Transfer.Infrastructure.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TransferLog transferLog)
        {
            _dbContext.Add(transferLog);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransfersLogs()
        {
            return _dbContext.TransferLogs;
        }
    }
}
