﻿
using Microsoft.EntityFrameworkCore;

namespace Graphapi.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext()
        {

        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Components> Components { get; set; }
    }
}
