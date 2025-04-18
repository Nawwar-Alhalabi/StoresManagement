using Microsoft.AspNetCore.Mvc;

namespace StoreAdministration.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult AddItem()
        {
            return View();
        }
    }
}
