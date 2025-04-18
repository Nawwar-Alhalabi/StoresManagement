using Microsoft.AspNetCore.Mvc;
using Store_Bl.BL;

namespace StoreAdministration.Controllers
{
    public class ChartController(ApplicationDbContext context) : Controller
    {

        public IActionResult GetOfficerData(int StoreId)
        {
            var DeliveryCount = new List<int>();
            var ReceiptCount = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                var count = context.DeliveryForms.Where(x => x.storeId == StoreId && x.CreatedAt.Month == i && x.CreatedAt.Year == DateTime.Now.Year).Count();
                DeliveryCount.Add(count);
            }


            for (int i = 1; i <= 12; i++)
            {
                var count = context.ReceiptForms.Where(x => x.StoreId == StoreId && x.CreatedAt.Month == i && x.CreatedAt.Year == DateTime.Now.Year).Count();
                ReceiptCount.Add(count);
            }

            var ChartData = new
            {
                Labels = new List<string> { "كانون ثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين أ", "تشرين ث", "كانون اول" },
                DeliveryData = DeliveryCount,
                ReceiptData = ReceiptCount
            };

            return Json(ChartData);
        }

        public IActionResult GetMedicalData(int medId)
        {
            var DeliveryCount = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                var count = context.DeliveryForms.Where(x => x.Med_Dep_Id == medId && x.CreatedAt.Month == i && x.CreatedAt.Year == DateTime.Now.Year).Count();
                DeliveryCount.Add(count);
            }

            var ChartData = new
            {
                Labels = new List<string> { "كانون ثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين أ", "تشرين ث", "كانون اول" },
                DeliveryData = DeliveryCount
            };

            return Json(ChartData);
        }
    }
}
