using System;

namespace Store_Bl.Models
{
    public class PurchaseOrderForm : Form
    {
        public PurchaseOrderForm()
        {
            ItemsPurchased = new List<Itemspurchased>();
        }
        public int StoreId { get; set; }
        public Store Store { get; set; } 
        public  List<Itemspurchased> ItemsPurchased{ get; set; }
     //   public OrderStatus ManagerApproval { get; set; } = OrderStatus.pending;
      //  public OrderStatus AccountantApproval { get; set; } = OrderStatus.pending;

        //public ReceiptForm? ReceiptForm { get; set; }
       
    }
}
