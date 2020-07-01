namespace Beke.AdminService.Data
{
    using Entities;
    using EFPostgresEngagement.Abstract;
    using EFPostgresEngagement.DbContextBase;
    using Microsoft.EntityFrameworkCore;
    
    public class BekeAdminDbContext : PostgresDbContextBase<BekeAdminDbContext>
    {
        public DbSet<Tenant> Tenants { get; set; }
        public BekeAdminDbContext(DbContextOptions<BekeAdminDbContext> options, IDbTracker dbTracker) : base(options,
            dbTracker)
        {
        }
    }
}