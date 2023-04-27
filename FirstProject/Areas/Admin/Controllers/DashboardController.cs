using FirstProject.Contexts;
using FirstProject.Models;
using FirstProject.viewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;


        }

        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            List<content> contents = _context.Contents.ToList();
            HomeViewModel homeViewModel = new()
            {
                Contents = contents,
                Sliders = sliders
            };

            return View(homeViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return View();
        }
    }
}
