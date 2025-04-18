namespace Store_Bl.Models
{
    public class MedicalDepartment
    {
        public MedicalDepartment()
        {
            DepartmentOrderForms = new List<DepartmentOrderForm>();
            deliveryForms = new List<DeliveryForm>();
        }
        public int Id { get; set; }
        public string Dep_Name { get; set; } = string.Empty;
        public string? Dep_Officer { get; set; } 
        public ICollection<DepartmentOrderForm> DepartmentOrderForms { get; set; }
        public ICollection<DeliveryForm> deliveryForms { get; set; }
        public ICollection<User> users { get; set; } = new List<User>();
    }
}
