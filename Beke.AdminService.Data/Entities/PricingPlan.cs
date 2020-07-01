namespace Beke.AdminService.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using EFPostgresEngagement.DataAnnotationAttributes;
    public class PricingPlan: EntityBase
    {
        [Required]
        [UniqueIndex]
        public string Name { get; set; }
        public int Price { get; set; }
        [UniqueIndex]
        public PricingPackage PricingPackage { get; set; }
        public ICollection<Tenant> Tenants { get; set; } = new HashSet<Tenant>();
    }
}