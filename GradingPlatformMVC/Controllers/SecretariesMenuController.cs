using Microsoft.AspNetCore.Mvc;

namespace GradingPlatformMVC.Controllers
{
    public class SecretariesMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
