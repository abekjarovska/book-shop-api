using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class History
    {
        public int PurchaseID { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string Status { get; set; }
        public DateTime DeliveredOn { get; set; }
        public string Book { get; set; }
        public string Note { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
