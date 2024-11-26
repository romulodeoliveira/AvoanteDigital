using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AvoanteDigital.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>(new CustomerMap().Configure);
        modelBuilder.Entity<User>(new UserMap().Configure);
        
        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Password);
    }
}