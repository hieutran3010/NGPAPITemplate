namespace Beke.AdminService.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using EFPostgresEngagement.DataAnnotationAttributes;

    public class Tenant : EntityBase
    {
        [Required]
        [UniqueIndex]
        public string BrandName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public Guid? PricingPlanId { get; set; }
        public PricingPlan PricingPlan { get; set; }
        public int DurationMonth { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        [SimpleIndex]
        public string OwnerUserId { get; set; }
        public byte[] Logo { get; set; }
        public byte[] InvertLogo { get; set; }
        public bool IsLocked { get; set; }
        public string LockReason { get; set; }
        public bool IsTrial { get; set; }
    }
}