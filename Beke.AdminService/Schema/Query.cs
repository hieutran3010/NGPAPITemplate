namespace Beke.AdminService.Schema
{
    using GraphQL.Conventions;
    using GraphQLDoorNet.Abstracts;
    using GraphQLDoorNet;
    using Data.Entities;
    
    internal sealed class Query: IQuery
    {
        public EntityQueryBase<Tenant> Tenant([Inject] EntityQueryBase<Tenant> entityQuery) => entityQuery;
    }
}