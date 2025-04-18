using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_Bl.Models
{
  // public enum OrderStatus {pending , approved , rejected };
    public class DepartmentOrderForm : Form
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int Med_Dep_Id { get; set; }
    //    public OrderStatus IsApproved { get; set; } = OrderStatus.pending;
        public MedicalDepartment MedicalDepartment { get; set; }

        //[NotMapped]
        //public DeliveryForm? deliveryForm { get; set; }
        public  List<DepartmentOrderItems> DepartmentOrderItems { get; set; } = new List<DepartmentOrderItems>();
    }
}
