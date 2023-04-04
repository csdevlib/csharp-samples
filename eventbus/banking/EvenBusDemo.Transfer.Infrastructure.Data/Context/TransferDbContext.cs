using EventBusDemo.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBusDemo.Transfer.Infrastructure.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
