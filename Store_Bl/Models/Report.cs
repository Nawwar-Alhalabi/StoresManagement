using System;

namespace Store_Bl.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int ItemCardNumber { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public string Unit { get; set; } = string.Empty;

        public string? Type { get; set; } 
        public int Folder { get; set; }
        public int Serial { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal ItemsTransfered { get; set; }
        public decimal FinalBalance { get; set; }
        public DateTime DateOfDeliver { get; set; }
        public string DeliveredTo { get; set; } = string.Empty;
        public string? Notes { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; } 
    }
}
