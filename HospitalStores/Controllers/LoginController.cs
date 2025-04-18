using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store_Bl.BL;
using Store_Bl.Models;

namespace StoreAdministration.Controllers
{
    public class LoginController(ClsUser clsUser) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Handle login form submission (POST)
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var usr = clsUser.CheckLogin(user);
                if (usr != null)
                {
                   
                    var userJson = JsonConvert.SerializeObject(usr, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    // Store serialized user in session
                    HttpContext.Session.SetString("CurrentUser", userJson);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "اسم المستخدم او كلمة المرور خاطئة");
                }

            }
            return View(user);
        }
    }
}
