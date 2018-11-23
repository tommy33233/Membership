using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("SubscriptionProduct")]
    public class UserSubscription
    {
        [Key, Column(Order = 1)]
        [Required]
        public int SubscriptionId { get; set; }

        [Key, Column(Order = 2)]
        [MaxLength(128)]
        [Required]
        public string UserId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}