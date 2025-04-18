using Microsoft.AspNetCore.Mvc;
using Store_Bl.BL;
using Store_Bl.Models;

namespace StoreAdministration.Controllers
{
    public class MedicalOfficerController : BaseController
    {
        private readonly ClsDepartmentOrderForm clsDepartmentOrderForm;

        public MedicalOfficerController(ClsDepartmentOrderForm clsDepartmentOrderForm)
        {
            this.clsDepartmentOrderForm = clsDepartmentOrderForm;
        }

        public IActionResult SubmitDepartmentOrderRequest(DepartmentOrderForm departmentOrderForm, int selectedStore, string selectedDepartment)
        {

            List<DepartmentOrderItems> lstItems = new List<DepartmentOrderItems>();
            foreach (var item in departmentOrderForm.DepartmentOrderItems)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var itm = new DepartmentOrderItems
                    {
                        SerialNumber = item.SerialNumber,
                        Name = item.Name,
                        Description = item.Description,
                        Unit = item.Unit,
                        ApprovedQuantity = item.ApprovedQuantity,
                        LastDateDelivered = item.LastDateDelivered,
                        LastQuantityDelivered = item.LastQuantityDelivered,
                        QuantityRequired = item.QuantityRequired,
                        ReasonForOrder = item.ReasonForOrder,
                        Notes = item.Notes,
                    };
                    lstItems.Add(itm);
                }
                departmentOrderForm.DepartmentOrderItems = lstItems;
            }


            departmentOrderForm.StoreId = selectedStore;
            departmentOrderForm.Med_Dep_Id = (int)currentUser.Medical_DepId!;

            if (lstItems.Count() == 0)
            {
                TempData["AlertMessage"] = "الرجاء ادخال مواد";
                return RedirectToAction("ShowDepartmentOrder", "Home");
            }
            if (lstItems.Any(x => x.QuantityRequired == 0))
            {
                TempData["AlertMessage"] = "الرجاء ادخال الكمية المطلوبة";
                return RedirectToAction("ShowDepartmentOrder", "Home");
            }

            if (!clsDepartmentOrderForm.Add(departmentOrderForm))
            {
                return RedirectToAction("Error");
            }
            TempData["AlertMessage"] = "تم إضافة الطلب بنجاح";
            return RedirectToAction("ShowDepartmentOrder", "Home");
        }

    }
}
