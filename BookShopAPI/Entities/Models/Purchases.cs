using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Purchases
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required(ErrorMessage = "DateOfPurchase is required")]
        public DateTime DateOfPurchase { get; set; }

        [Required(ErrorMessage = "PurchasedBy is required")]
        public string PurchasedBy { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(1, ErrorMessage = "Status can't be longer than 1 character")]
        public string Status { get; set; }

        
        public DateTime DeliveredOn { get; set; }

        

    }
}
