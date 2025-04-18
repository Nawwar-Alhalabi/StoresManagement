using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? StoreName { get; set; }
        public string? Storekeeper { get; set; }
        public ICollection<ReceiptForm> ReceiptForms { get; set; } = new List<ReceiptForm>();
        public ICollection<PurchaseOrderForm> PurchaseOrderForms { get; set; } = new List<PurchaseOrderForm>();
        public ICollection<DepartmentOrderForm> DepartmentOrderForms { get; set; } = new List<DepartmentOrderForm>();
        public ICollection<DeliveryForm> deliveryForms { get; set; } = new List<DeliveryForm>();
        public ICollection<User> users { get; set; } = new List<User>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
