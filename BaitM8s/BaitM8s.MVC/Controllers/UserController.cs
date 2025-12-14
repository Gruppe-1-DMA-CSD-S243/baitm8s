using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SetAngler()
        {
            HttpContext.Session.SetInt32("UserType", 0);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SetOwner()
        {
            HttpContext.Session.SetInt32("UserType", 1);
            return RedirectToAction("Index", "Home");
        }
    }
}