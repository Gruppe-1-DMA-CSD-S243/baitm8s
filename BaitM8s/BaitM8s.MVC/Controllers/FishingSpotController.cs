using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class FishingSpotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
