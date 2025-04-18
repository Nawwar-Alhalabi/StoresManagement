using System.Text;

namespace Store_Bl.Models
{
    public class DeliveryForm : Form
    {
        public int Med_Dep_Id { get; set; }
        public MedicalDepartment? medicalDepartment{ get; set; }
       
        public int storeId{ get; set; }
        public Store store{ get; set; } 
        public int RelatedFolder { get; set; }
        public int RelatedSerial { get; set; }
        public List<ItemsDelivered> ItemsDelivered { get; set; } = new List<ItemsDelivered>();
        //public DepartmentOrderForm departmentOrderForm { get; set; } 
        //public int departmentOrderFormId { get; set; }


    }
}
