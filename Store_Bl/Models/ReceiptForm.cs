using Store_Bl.Models;
using System;

namespace Store_Bl.Models
{
    public class ReceiptForm : Form
    {
        public string TypeOfForm { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public int? InvoiceNumber { get; set; }
        public string? CreatedBy { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; } 
        public decimal? TotalAmount { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? RelatedPurchaseNumber { get; set; }
     
        public int? DocumentNumber { get; set; } = null;
        public DateTime? DocumentDate { get; set; } = null;
        public List<ItemsReceived> ItemsReceived { get; set; } = new List<ItemsReceived>();
        //public PurchaseOrderForm? PurchaseOrderForm { get; set; }
        //public int? PurchaseOrderFormId { get; set; }
    }
}
