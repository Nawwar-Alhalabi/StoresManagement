using Microsoft.AspNetCore.Mvc;

namespace StoreAdministration.Controllers
{
    public class ManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
