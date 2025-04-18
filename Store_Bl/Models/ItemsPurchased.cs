using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.Models
{
    public class Itemspurchased
    {
        public int Id { get; set; }
        public int? SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Unit { get; set; } 
        public decimal? NumberOfItems { get; set; }
        public decimal? Min { get; set; } 
        public decimal? Max { get; set; } 
        public string? ReasonOfPurchase { get; set; }
        
        public decimal QuantityToPurchase { get; set; }
        public decimal? ExpectedPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Notes { get; set; }

        public int PurchaseOrderFormId { get; set; }
        public PurchaseOrderForm PurchaseForm { get; set; }

    }
}
