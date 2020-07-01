namespace Beke.AdminService.InputModels
{
    using System;
    using GraphQL.Conventions.Attributes.Execution.Wrappers;
    using GraphQLDoorNet.Attributes;
    using Data.Entities;
    
    [InputType(EntityType = typeof(Tenant))]
    public class TenantInput: OptionalWrapper
    {
        public string BrandName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public Guid? PricingPlanId { get; set; }
        public string OwnerUserId { get; set; }
        public byte[] Logo { get; set; }
        public byte[] InvertLogo { get; set; }
    }
}