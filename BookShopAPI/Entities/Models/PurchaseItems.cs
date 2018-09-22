using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Entities.Models
{
    public  class PurchaseItems
    {
        [Key]
        public int PurchaseItemId { get; set; }

        [Required(ErrorMessage = "Purchase is required")]
        public int Purchase { get; set; }

        [Required(ErrorMessage = "Book is required")]
        public string Book { get; set; }

        [Required(ErrorMessage = "Qty is required")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        public decimal UnitPrice { get; set; }

        public string Note { get; set; }

    }
}