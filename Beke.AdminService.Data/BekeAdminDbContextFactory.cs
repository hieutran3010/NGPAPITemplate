using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Beke.AdminService.Data
{
    public class BekeAdminDbContextFactory : IDesignTimeDbContextFactory<BekeAdminDbContext>
    {
        public BekeAdminDbContext CreateDbContext(string[] args)
        {
            var connection = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            var optionsBuilder = new DbContextOptionsBuilder<BekeAdminDbContext>();
            optionsBuilder.UseNpgsql(connection ?? "Host=localhost;Port=5432;Username=postgres;Password=1nS1t3;Database=Beke.Admin;");

            return new BekeAdminDbContext(optionsBuilder.Options, null);
        }
    }
}