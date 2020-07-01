
namespace Beke.AdminService.Schema
{
    using GraphQL.Conventions;
    using GraphQLDoorNet.Abstracts;
    using GraphQLDoorNet;
    using Data.Entities;
    using InputModels;

    internal sealed class Mutation : IMutation
    {
        public EntityMutationBase<Tenant, TenantInput> Tenant(
            [Inject] EntityMutationBase<Tenant, TenantInput> entityMutation) =>
            entityMutation;
    }
}