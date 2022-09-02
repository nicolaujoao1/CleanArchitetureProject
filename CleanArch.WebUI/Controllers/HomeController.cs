using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
