namespace Store_Bl.Models
{
    public class ItemsDelivered
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Unit { get; set; } = string.Empty;

        public decimal? QuantityDelivered { get; set; }
        public string? DeliveredTo { get; set; } = null!;
        public int? ItemCardNumber { get; set; }
        public string? Notes { get; set; }

        public int DeliveryFormId { get; set; }
        public DeliveryForm DeliveryForm { get; set; } 
    }
}
