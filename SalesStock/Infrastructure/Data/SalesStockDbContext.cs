using Microsoft.EntityFrameworkCore;
using SalesStock.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SalesStock.Infrastructure.Data
{
    public class SalesStockDbContext : DbContext
    {
        public SalesStockDbContext(DbContextOptions<SalesStockDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesStockDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
