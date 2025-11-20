using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishingSpotsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
