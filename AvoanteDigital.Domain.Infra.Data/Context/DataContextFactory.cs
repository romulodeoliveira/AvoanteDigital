using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AvoanteDigital.Domain.Infra.Data.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public static string DbConfig { get; } = "Server=localhost;Port=3306;Database=AvoanteDigital;Uid=root;Pwd=CSharp@123;";

        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(DbConfig, ServerVersion.AutoDetect(DbConfig));
            return new DataContext(optionsBuilder.Options);
        }
    }
}