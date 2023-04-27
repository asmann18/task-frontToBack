using FirstProject.Contexts;
using FirstProject.Models;
using FirstProject.viewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;


        }
        
        public IActionResult Index()
        {

            List<content> contents = _context.Contents.ToList();
            List<Slider> sliders = _context.Sliders.ToList();
            HomeViewModel homeViewModel = new()
            {
                Contents = contents,
                Sliders = sliders
            };
            return View(homeViewModel);
        }
    }
}
