namespace Store_Bl.Models
{
    public class DepartmentOrderItems
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal QuantityRequired { get; set; }
        public string? ReasonForOrder { get; set; }
        public decimal? LastQuantityDelivered { get; set; }
        public DateTime? LastDateDelivered { get; set; }
        public decimal? ApprovedQuantity { get; set; }
        public  string? Notes { get; set; }

        public int DepartmentOrderFormId { get; set; }
        public DepartmentOrderForm DepartmentOrderForm { get; set; }

    }

}
