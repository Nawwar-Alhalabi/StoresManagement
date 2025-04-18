using Microsoft.AspNetCore.Mvc;

namespace StoreAdministration.Controllers
{
    public class ObserverController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
