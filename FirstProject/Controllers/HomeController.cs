using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
