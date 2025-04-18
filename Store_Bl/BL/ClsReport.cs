using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Bl.Models;

namespace Store_Bl.BL
{
    public class ClsReport(ApplicationDbContext context)
    {
        public List<ReportViewModel> GetReportDetails(int ItemCard)
        {
            try
            {
                var Reports = context.Reports.Where(x => x.ItemCardNumber == ItemCard).Select(x => new ReportViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    NumberOfDoucument = string.Concat(x.Folder, "-", x.Serial),
                    CreatedAt = x.CreatedAt,
                    ItemsTransfered = x.ItemsTransfered,
                    FinalBalance = x.FinalBalance,
                    DateOfDeliver = x.DateOfDeliver,
                    DeliveredTo = x.DeliveredTo,
                    Notes = x.Notes ?? string.Empty,
                    Name = x.ItemName ?? string.Empty,
                    Unit = x.Unit ?? string.Empty,
                    Min = x.Min ?? 0,
                    Max = x.Max ?? 0,
                }).ToList();
                return Reports;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<ReportViewModel> GetReportDetailsForManager(string itemName, int storeId)
        {
            try
            {
                var Reports = context.Reports.Where(x => x.ItemName == itemName && x.StoreId == storeId).Select(x => new ReportViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    NumberOfDoucument = string.Concat(x.Folder, "-", x.Serial),
                    CreatedAt = x.CreatedAt.Date,
                    ItemsTransfered = x.ItemsTransfered,
                    FinalBalance = x.FinalBalance,
                    DateOfDeliver = x.DateOfDeliver.Date,
                    DeliveredTo = x.DeliveredTo,
                    Notes = x.Notes ?? string.Empty,
                    Name = x.ItemName ?? string.Empty,
                    Unit = x.Unit ?? string.Empty,
                    Min = x.Min ?? 0,
                    Max = x.Max ?? 0,
                }).ToList();
                return Reports;
            }
            catch (Exception)
            {
                return null;
            }
        }

       

    }
 
}
