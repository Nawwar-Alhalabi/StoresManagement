using System.ComponentModel.DataAnnotations.Schema;

namespace Store_Bl.Models
{

    [NotMapped]
    public class ReportViewModel
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? NumberOfDoucument { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal ItemsTransfered { get; set; }
        public decimal? FinalBalance { get; set; } = 0;
        public DateTime DateOfDeliver { get; set; }
        public string? DeliveredTo { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
