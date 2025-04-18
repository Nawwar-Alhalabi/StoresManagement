namespace Store_Bl.Models
{
    public class ItemsReceived
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal? QuantityRecieved { get; set; }
        public decimal? Price { get; set; }
        public int? ItemCardNumber { get; set; }
        public string? Notes { get; set; }
        public int ReceiptFormId { get; set; }
        public ReceiptForm ReceiptForm { get; set; } 
    }
}
