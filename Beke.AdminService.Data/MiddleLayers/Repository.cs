namespace Beke.AdminService.Data.MiddleLayers
{
    using EFPostgresEngagement;
    using GraphQLDoorNet.Abstracts;

    public class Repository<TEntity> : RepositoryBase<TEntity, BekeAdminDbContext>,
        IRepository<TEntity>
        where TEntity : class, IEntityBase, new()
    {
        public Repository(BekeAdminDbContext dbContext) : base(dbContext)
        {
        }
    }
}