using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AvoanteDigital.Domain.Infra.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>(new CustomerMap().Configure);
    }
}