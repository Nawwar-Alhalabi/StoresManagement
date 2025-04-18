using Microsoft.AspNetCore.Mvc;
using Store_Bl.BL;
using Store_Bl.Models;

namespace StoreAdministration.Controllers
{
    public class OfficerController(ClsPurchaseOrderForm clsPurchaseOrderForm, ClsReceiptForm clsReceiptForm, ClsDeliveryForm clsDeliveryForm, ClsStore clsStore, ClsMedicalDepartment medicalDepartment) : BaseController
    {
        public IActionResult SubmitPurchaseRequest(PurchaseOrderForm model)
        {
            List<Itemspurchased> lstItems = new List<Itemspurchased>();
            foreach (var item in model.ItemsPurchased)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var itm = new Itemspurchased
                    {
                        SerialNumber = item.SerialNumber,
                        Name = item.Name,
                        Unit = item.Unit,
                        Description = item.Description,
                        Min = item.Min,
                        Max = item.Max,
                        NumberOfItems = item.NumberOfItems is null ? 0 : item.NumberOfItems,
                        QuantityToPurchase = item.QuantityToPurchase,
                        ReasonOfPurchase = item.ReasonOfPurchase,
                        ExpectedPrice = item.ExpectedPrice,
                        TotalPrice = item.TotalPrice is null ? 0 : item.TotalPrice,
                        Notes = item.Notes,
                    };
                    lstItems.Add(itm);
                }
                model.ItemsPurchased = lstItems;

                model.StoreId = (int)currentUser.StoreId;
            }

            if (lstItems.Count() == 0)
            {
                TempData["AlertMessage"] = "الرجاء ادخال مواد";
                return RedirectToAction("AddPurchaseForm", "Home");
            }
            if (lstItems.Any(x => x.QuantityToPurchase == 0))
            {
                TempData["AlertMessage"] = "الرجاء ادخال الكمية المطلوبة";
                return RedirectToAction("AddPurchaseForm", "Home");
            }

            if (!clsPurchaseOrderForm.Add(model))
            {
                return RedirectToAction("Error");
            }
            TempData["AlertMessage"] = "تم إضافة الطلب بنجاح";
            return RedirectToAction("AddPurchaseForm", "Home");
        }

        public IActionResult SubmitReceiptRequest(ReceiptForm receiptForm)
        {
            List<ItemsReceived> lstItems = new List<ItemsReceived>();
            foreach (var item in receiptForm.ItemsReceived)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var itm = new ItemsReceived
                    {
                        SerialNumber = item.SerialNumber,
                        Name = item.Name,
                        Description = item.Description,
                        Unit = item.Unit,
                        QuantityRecieved = item.QuantityRecieved,
                        ItemCardNumber = item.ItemCardNumber,
                        Notes = item.Notes,
                    };
                    lstItems.Add(itm);
                }
                receiptForm.ItemsReceived = lstItems;
            }

            var TotalQuantity = lstItems.Count();
            var TotalPrice = lstItems.Sum(itm => itm.Price);

            receiptForm.StoreId = (int)currentUser.StoreId;
            receiptForm.CreatedBy = currentUser.UserName;
            receiptForm.TypeOfForm = "مذكرة استلام";
            receiptForm.TotalAmount = TotalQuantity;
            receiptForm.TotalPrice = TotalPrice;

            if (lstItems.Count() == 0)
            {
                TempData["AlertMessage"] = "الرجاء ادخال مواد";
                return RedirectToAction("ShowReceiptForm", "Home");
            }
            if (lstItems.Any(x => x.QuantityRecieved == 0 || x.QuantityRecieved == null))
            {
                TempData["AlertMessage"] = "الرجاء ادخال الكمية المستلمة";
                return RedirectToAction("ShowReceiptForm", "Home");
            }

            if (!clsReceiptForm.Add(receiptForm))
            {
                return RedirectToAction("Error");
            }
            TempData["AlertMessage"] = "تم إنشاء مذكرة الاستلام بنجاح";
            return RedirectToAction("ShowReceiptForm" , "Home");
        }

        public IActionResult SubmitEntryRequest(ReceiptForm receiptForm)
        {
            List<ItemsReceived> lstItems = new List<ItemsReceived>();
            foreach (var item in receiptForm.ItemsReceived)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var itm = new ItemsReceived
                    {
                        SerialNumber = item.SerialNumber,
                        Name = item.Name,
                        Description = item.Description,
                        Unit = item.Unit,
                        QuantityRecieved = item.QuantityRecieved,
                        ItemCardNumber = item.ItemCardNumber,
                        Notes = item.Notes,
                    };
                    lstItems.Add(itm);
                }
                receiptForm.ItemsReceived = lstItems;
            }

            var TotalQuantity = lstItems.Count();
            var TotalPrice = lstItems.Sum(itm => itm.Price);

            receiptForm.StoreId = (int)currentUser.StoreId;
            receiptForm.CreatedBy = currentUser.UserName;
            receiptForm.TypeOfForm = "مذكرة ادخال";
            receiptForm.TotalAmount = TotalQuantity;
            receiptForm.TotalPrice = TotalPrice;

            if (lstItems.Count() == 0)
            {
                TempData["AlertMessage"] = "الرجاء ادخال مواد";
                return RedirectToAction("ShowEntryForm", "Home");
            }
            if (lstItems.Any(x => x.QuantityRecieved == 0 || x.QuantityRecieved == null))
            {
                TempData["AlertMessage"] = "الرجاء ادخال الكمية المستلمة";
                return RedirectToAction("ShowEntryForm", "Home");
            }
         
            if (!clsReceiptForm.Add(receiptForm))
            {
                return RedirectToAction("Error");
            }
            TempData["AlertMessage"] = "تم إنشاء مذكرة الادخال بنجاح";
            return RedirectToAction("ShowEntryForm", "Home");
        }

        public IActionResult SubmitDeliveryRequest(DeliveryForm deliveryForm, string selectedDepartment)
        {
            List<ItemsDelivered> lstItems = new List<ItemsDelivered>();
            foreach (var item in deliveryForm.ItemsDelivered)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var itm = new ItemsDelivered
                    {
                        SerialNumber = item.SerialNumber,
                        Name = item.Name,
                        Description = item.Description,
                        Unit = item.Unit,
                        DeliveredTo = item.DeliveredTo,
                        ItemCardNumber = item.ItemCardNumber,
                        QuantityDelivered = item.QuantityDelivered,
                        Notes = item.Notes,
                    };
                    lstItems.Add(itm);
                }
            }
            deliveryForm.ItemsDelivered = lstItems;

            var store = clsStore.GetStoreForUser(currentUser);

            var Med_Department = medicalDepartment.GetByName(selectedDepartment);

            deliveryForm.Med_Dep_Id = Med_Department.Id;
            deliveryForm.storeId = store.Id;
            //using (var context = new ApplicationDbContext())
            //{
            //    var Ord_id = context.DepartmentOrderForms.SingleOrDefault(x => x.Folder == deliveryForm.RelatedFolder && x.Serial == deliveryForm.RelatedSerial);
            //    if (Ord_id == null)
            //    {
            //        return RedirectToAction("Error");
            //    }
            //    else
            //    {
            //        deliveryForm.departmentOrderFormId = Ord_id.Id;
            //    }
            //}


            if (lstItems.Count() == 0)
            {
                TempData["AlertMessage"] = "الرجاء ادخال مواد";
                return RedirectToAction("ShowDeliveryForm", "Home");
            }
            if (lstItems.Any(x => x.QuantityDelivered == 0 || x.QuantityDelivered == null))
            {
                TempData["AlertMessage"] = "الرجاء ادخال الكمية المسلمة";
                return RedirectToAction("ShowDeliveryForm", "Home");
            }
            
            if (!clsDeliveryForm.Add(deliveryForm))
            {
                return RedirectToAction("Error");
            }
            TempData["AlertMessage"] = "تم إنشاء مذكرة التسليم بنجاح";
            return RedirectToAction("ShowDeliveryForm" , "Home");
        }

    }

 
}
