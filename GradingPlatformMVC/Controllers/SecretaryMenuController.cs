using Microsoft.AspNetCore.Mvc;

namespace GradingPlatformMVC.Controllers
{
    public class SecretaryMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
