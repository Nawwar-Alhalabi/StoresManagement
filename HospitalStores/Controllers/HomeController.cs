
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;
using Store_Bl.BL;
using Store_Bl.Models;
using StoreAdministration.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace StoreAdministration.Controllers
{
    public class BaseController : Controller
    {
        protected User currentUser;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");

            if (userJson != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(userJson);
                ViewBag.user = currentUser;
            }
            else
            {
                context.Result = RedirectToAction("Login", "Login");
            }

            base.OnActionExecuting(context);
        }
    }
    public class HomeController(ApplicationDbContext context, ClsStore clsStore, ClsReport clsReport, ClsMedicalDepartment MedicalDep) : BaseController
    {
        public IActionResult Index()
        {
            if (currentUser.Role == Store_Bl.Models.User.enRoles.Officer)
            {
                //var pendingPurchaseCount = context.PurchaseOrderForms.Where(x => x.StoreId == currentUser.StoreId && (x.ManagerApproval == OrderStatus.pending || x.AccountantApproval == OrderStatus.pending)).Count();
                //ViewBag.PendingpurchaseCount = pendingPurchaseCount;

                //var pendingDepartmentCount = context.DepartmentOrderForms.Where(x => x.StoreId == currentUser.StoreId && x.IsApproved == OrderStatus.pending).Count();
                //ViewBag.PendingDepartmentCount = pendingDepartmentCount;

                var FinalBalanceOfItems = context.Reports
                  .Where(r => r.StoreId == currentUser.StoreId) // Filter before grouping
                  .GroupBy(r => r.ItemName)
                  //.Where(g => g.Any(r => r.FinalBalance <= 0)) // Apply a condition on grouped items (equivalent to HAVING)
                  .Select(g => g.OrderByDescending(r => r.Id).FirstOrDefault()) // Order within each group and select the first
                  .ToList();

                if (FinalBalanceOfItems != null && FinalBalanceOfItems.Any(x => x.FinalBalance <= 0))
                {
                    var lstrunOut = FinalBalanceOfItems.Where(x => x.FinalBalance <= 0).ToList();
                    ViewBag.runOutItems = lstrunOut;
                }
                else
                {
                    ViewBag.runOutItems = new List<Report>();
                }
            }

            //if (currentUser.Role == Store_Bl.Models.User.enRoles.MedicalEmployee)
            //{
            //    var PendingOrderCount = context.DepartmentOrderForms.Where(x => x.Med_Dep_Id == currentUser.Medical_DepId && x.IsApproved == OrderStatus.pending).Count();
            //    ViewBag.pendingOrderCount = PendingOrderCount;
            //}

            return View(currentUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowPurchaseForm()
        {
            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.store = store;

            return View();
        }
        public IActionResult ShowReceiptForm(int PurchaseId)
        {
            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.Store = store;

            //ClsPurchaseOrderForm clsPurchaseOrderForm = new ClsPurchaseOrderForm();
            //ViewBag.RelatedPurchaseOrder = clsPurchaseOrderForm.GetById(PurchaseId);

            return View();
        }
        public IActionResult ShowEntryForm()
        {
            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.Store = store;
            return View();
        }


        public IActionResult ShowDepartmentOrder()
        {
            List<Store> StoresNames = new List<Store>();

            var stores = clsStore.GetAll();
            foreach (var item in stores)
            {
                StoresNames.Add(item);
            }
            ViewBag.storesNames = StoresNames;
            ViewBag.DepartmentName = currentUser?.MedicalDepartment?.Dep_Name;
            return View();
        }


        public IActionResult ShowDeliveryForm(int OrderId)
        {
            List<string> Med_Dep_Names = new List<string>();
            
            var MedicalDeps = MedicalDep.GetAll();
            foreach (var item in MedicalDeps)
            {
                Med_Dep_Names.Add(item.Dep_Name);
            }

            ViewBag.DepartmentsNames = Med_Dep_Names;

            //ClsDepartmentOrderForm clsDepartmentOrderForm = new ClsDepartmentOrderForm();
            //ViewBag.RelatedDepartmentOrder = clsDepartmentOrderForm.GetById(OrderId);

            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.Store = store;
            return View();
        }

        [HttpGet]
        public JsonResult CheckDuplicateDelivery(int folder, int serial)
        {
            var exists = context.DeliveryForms.Any(e => e.Folder == folder && e.Serial == serial);
            return Json(new { isDuplicate = exists });
        }

        [HttpGet]
        public JsonResult CheckDuplicatePurchase(int folder, int serial)
        {
            var exists = context.PurchaseOrderForms.Any(e => e.Folder == folder && e.Serial == serial);
            return Json(new { isDuplicate = exists });
        }
        [HttpGet]
        public JsonResult CheckDuplicateReceipt(int folder, int serial)
        {
            var exists = context.ReceiptForms.Any(e => e.Folder == folder && e.Serial == serial);
            return Json(new { isDuplicate = exists });
        }
        [HttpGet]
        public JsonResult CheckDuplicateDepartment(int folder, int serial)
        {
            var exists = context.DepartmentOrderForms.Any(e => e.Folder == folder && e.Serial == serial);
            return Json(new { isDuplicate = exists });
        }

        public IActionResult ItemCards()
        {
            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.store = store;
            return View();
        }

        public IActionResult SearchItemCard(int cardNum) // apply this if you want to search by card number
        {
           
            var ItemCardDetails = clsReport.GetReportDetails(cardNum);

            //var itemDetails = clsReport.GetItemDetailsByItemCard(cardNum);

            ViewBag.itemCardDetails = ItemCardDetails;

            return View("ItemCards");
        }   
        public IActionResult SearchItemCardByName(string itemName)
        {
           
            var ItemCardDetails = clsReport.GetReportDetailsForManager(itemName, currentUser.StoreId ?? 0);

            //var itemDetails = clsReport.GetItemDetailsByItemCard(cardNum);

            ViewBag.itemCardDetails = ItemCardDetails;

            var store = clsStore.GetStoreForUser(currentUser);
            ViewBag.store = store;

            return View("ItemCards");
        }


        //public IActionResult PendingDepartmentOrders()
        //{
        //    ClsDepartmentOrderForm DepartmentOrder = new ClsDepartmentOrderForm();
        //    var pendingOrders = DepartmentOrder.GetAllPendingDepartmentOrders();
        //    ViewBag.pendingOrders = pendingOrders;
        //    return View();
        //}

        //public IActionResult PendingOrdersForDepartment(int MedId)
        //{
        //    ClsDepartmentOrderForm DepartmentOrder = new ClsDepartmentOrderForm();
        //    var PendingOrders = DepartmentOrder.GetAllPendingOrdersForDepartment(MedId);
        //    ViewBag.PendingOrders = PendingOrders;
        //    return View();
        //}


        //public IActionResult ApproveDepartmentOrder(int Id)
        //{
        //    ClsDepartmentOrderForm DepartmentOrder = new ClsDepartmentOrderForm();
        //    DepartmentOrder.ApproveDepartmentOrder(Id);

        //    return RedirectToAction("PendingDepartmentOrders");

        //}
        //public IActionResult RejectDepartmentOrder(int Id)
        //{
        //    ClsDepartmentOrderForm DepartmentOrder = new ClsDepartmentOrderForm();
        //    DepartmentOrder.RejectDepartmentOrder(Id);

        //    return RedirectToAction("PendingDepartmentOrders");

        //}

        //public IActionResult PendingPurchaseOrders()
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    var pendingPurchaseOrders = PurchaseOrder.GetAllPendingPurchaseOrders();
        //    ViewBag.PendingOrders = pendingPurchaseOrders;
        //    return View();
        //}

        //public IActionResult ApprovePurchaseOrder(int Id)
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    PurchaseOrder.ApprovePurchaseOrder(Id);
        //    return RedirectToAction("PendingPurchaseOrders");
        //}

        //public IActionResult RejectPurchaseOrder(int Id)
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    PurchaseOrder.RejectPurchaseOrder(Id);

        //    return RedirectToAction("PendingPurchaseOrders");

        //}


        //public IActionResult PendingPurchaseOrdersForAccountant()
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    var pendingPurchaseOrders = PurchaseOrder.GetAllPendingPurchaseOrdersForAccountant();
        //    ViewBag.AccountantPendingOrders = pendingPurchaseOrders;
        //    return View();
        //}

        //public IActionResult ApprovePurchaseOrderForAccountant(int Id)
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    PurchaseOrder.ApprovePurchaseOrderForAccountant(Id);
        //    return RedirectToAction("PendingPurchaseOrdersForAccountant");
        //}
        //public IActionResult RejectPurchaseOrderForAccountant(int Id)
        //{
        //    ClsPurchaseOrderForm PurchaseOrder = new ClsPurchaseOrderForm();
        //    PurchaseOrder.RejectPurchaseOrderForAccountant(Id);

        //    return RedirectToAction("PendingPurchaseOrdersForAccountant");

        //}


        //public IActionResult ShowApprovedDepartmentOrdersForOfficer(int StoreId)
        //{
        //    ClsDepartmentOrderForm clsDepartmentOrderForm = new ClsDepartmentOrderForm();
        //    var DepartmentOrders = clsDepartmentOrderForm.ShowApprovedDepartmentOrdersForOfficer(StoreId);
        //    ViewBag.ApprovedDepartmentOrders = DepartmentOrders;

        //    ClsDeliveryForm clsDeliveryForm = new ClsDeliveryForm();
        //    var Delivery = clsDeliveryForm.GetAllDeliveryFormForStore(StoreId);
        //    ViewBag.DeliveryForms = Delivery;

        //    return View();
        //}
        //public IActionResult ShowApprovedPurchaseOrdersForOfficer(int StoreId)
        //{
        //    ClsPurchaseOrderForm clsPurchaseOrderForm = new ClsPurchaseOrderForm();
        //    var PurchaseOrders = clsPurchaseOrderForm.ShowApprovedPurchaseOrdersForOfficer(StoreId);
        //    ViewBag.ApprovedPurchaseOrders = PurchaseOrders;

        //    ClsReceiptForm clsReceiptForm = new ClsReceiptForm();
        //    var Receipt = clsReceiptForm.GetAllReceiptFormForStore(StoreId);
        //    ViewBag.ReceiptForms = Receipt;
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult SearchItemsInStore(string term, int StoreId)
        {
            try
            {
                var items = (from rf in context.ReceiptForms
                             join ir in context.ItemsReceived on rf.Id equals ir.ReceiptFormId
                             where rf.StoreId == StoreId && ir.Name.Contains(term)
                             select new
                             {
                                 ir.SerialNumber,
                                 ir.Description,
                                 ir.Unit,
                                 ir.Name
                             }).Distinct().ToList();

                return Json(items);

            }
            catch (Exception)
            {

            }
            return Json(null);
        }
        public JsonResult SearchItemsForPurchase(string term, int StoreId)
        {
            try
            {

                //var items = context.Reports
                //         .Where(x => x.StoreId == StoreId && x.ItemName.Contains(term)) // Filter by store and term
                //         .GroupBy(x => x.ItemName) // Group by ItemName
                //         .AsEnumerable() // Switch to LINQ-to-Objects
                //         .Select(g => g.OrderByDescending(x => x.Id).FirstOrDefault()) // Get the latest item for each group
                //         .Select(x => new
                //         {
                //             x.ItemCardNumber,
                //             x.FinalBalance,
                //             x.Unit,
                //             x.ItemName
                //         })
                //         .ToList();

                //return Json(items);

                var items = context.Reports
                        .Where(x => x.StoreId == StoreId && x.ItemName.Contains(term)) // Filter by store and term
                        .Select(x => new
                        {
                            x.ItemCardNumber,
                            x.FinalBalance,
                            x.Unit,
                            x.ItemName
                        }).AsEnumerable()
                        .DistinctBy(r => r.ItemName)
                        .ToList();

                return Json(items);

            }
            catch (Exception)
            {
                // Log the exception here if needed
            }

            return Json(null);
        }


        [HttpGet]
        public JsonResult CheckInvoiceNumber(int invoiceNumber)
        {

            bool exists = context.ReceiptForms.Any(i => i.InvoiceNumber == invoiceNumber);
            return Json(new { exists = exists });

        }


        public IActionResult ReceiptHistory()
        {

            try
            {
                var Receipt = context.ReceiptForms.Include(x => x.ItemsReceived).Include(x => x.store)
                .Where(x => x.StoreId == currentUser.StoreId).OrderByDescending(x => x.Id)
                .Take(50).ToList();
                ViewBag.ReceiptForm = Receipt;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }

        public IActionResult DeliveryHistory()
        {

            try
            {
                var delivery = context.DeliveryForms.Include(x => x.ItemsDelivered).Include(x => x.store).Include(x => x.medicalDepartment)
                        .Where(x => x.storeId == currentUser.StoreId).OrderByDescending(x => x.Id).Take(50).ToList();
                ViewBag.DeliveryForm = delivery;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }
        public IActionResult PurchaseHistory()
        {

            try
            {
                var Purchase = context.PurchaseOrderForms.Include(x => x.ItemsPurchased).Include(x => x.Store)
                        .Where(x => x.StoreId == currentUser.StoreId).OrderByDescending(x => x.Id).Take(50).ToList();
                ViewBag.PurchaseForm = Purchase;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }
        public IActionResult DepOrderHistory()
        {
            try
            {
                var Department = context.DepartmentOrderForms.Include(x => x.DepartmentOrderItems).Include(x => x.Store).Include(x => x.MedicalDepartment)
                        .Where(x => x.StoreId == currentUser.StoreId).OrderByDescending(x => x.Id).Take(50).ToList();
                ViewBag.DepartmentForm = Department;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }
        public IActionResult LogOut()
        {
            try
            {
                // Clear session data
                HttpContext.Session.Clear();

                // Reset the current user object
                currentUser = new User();

                // Redirect to the Login page
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                // Redirect to an error page in case of any issues
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public JsonResult ValidateQuantity(int quantity, int itemSerial)
        {
            // Fetch the item's final balance from the database
            var item = context.Reports
              .Where(x => x.StoreId == currentUser.StoreId && x.ItemCardNumber == itemSerial)
              .OrderBy(x => x.Id)
              .LastOrDefault();


            if (item != null)
            {

                bool isValid = quantity <= item.FinalBalance; // Check if quantity is valid
                return Json(new { isValid });
            }

            // If the item is not found, return an invalid response
            return Json(new { isValid = false });

        }

        public IActionResult ShowStoresReportsForManager()
        {
            if (currentUser.Role != Store_Bl.Models.User.enRoles.Manager && currentUser.Role != Store_Bl.Models.User.enRoles.observer)
            {
                return RedirectToAction("Error");
            }

            try
            {
                ViewBag.storesNames = clsStore.GetAll();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }

        public IActionResult SearchStoreReports(string itemName, int selectedStore)
        {
            if (currentUser.Role != Store_Bl.Models.User.enRoles.Manager && currentUser.Role != Store_Bl.Models.User.enRoles.observer)
            {
                return RedirectToAction("Error");
            }
            var ItemCardDetails = clsReport.GetReportDetailsForManager(itemName, selectedStore);

            //var itemDetails = clsReport.GetItemDetailsByItemCard(cardNum);

            ViewBag.itemCardDetails = ItemCardDetails;

            return View("ShowStoresReportsForManager");
        }


        public IActionResult ShowDepartmentReportsForManager()
        {
            if (currentUser.Role != Store_Bl.Models.User.enRoles.Manager)
            {
                return RedirectToAction("Error");
            }

            try
            {
                List<MedicalDepartment> DepartmentNames = new List<MedicalDepartment>();

               
                var departments = MedicalDep.GetAll();
                foreach (var item in departments)
                {
                    DepartmentNames.Add(item);
                }
                ViewBag.DepartmentNames = DepartmentNames;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }

        [HttpGet]
        public JsonResult SearchDepartmentReports(string itemName, string selectedDepartment)
        {
            //ClsReport clsReport = new ClsReport();
            //var ItemCardDetails = clsReport.GetDepartmentReportForManager(itemName, selectedDepartment);

            //var itemDetails = clsReport.GetItemDetailsByItemCard(cardNum);

            //ViewBag.itemCardDetails = ItemCardDetails;
            var ItemCount = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                var count = context.Reports.Where(x => x.ItemName == itemName && x.DeliveredTo == selectedDepartment
                && x.Type == "مذكرة تسليم" && x.CreatedAt.Month == i && x.CreatedAt.Year == DateTime.Now.Year).Sum(x => x.ItemsTransfered);
                ItemCount.Add((int)count);
            }

            var ChartData = new
            {
                Labels = new List<string> { "كانون ثاني", "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين أ", "تشرين ث", "كانون اول" },
                DeliveryData = ItemCount,

            };

            return Json(ChartData);
        }

        [HttpGet]
        public JsonResult SearchDeliveredItems(string selectedDepartment)
        {
            try
            {
                var items = (from ir in context.ItemsDelivered
                             where ir.DeliveredTo == selectedDepartment
                             select new
                             {
                                 Name = ir.Name
                             }).Distinct().ToList();

                return Json(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return Json(null);
        }

    }
}
