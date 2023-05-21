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



 
     


        public IActionResult deleteService(int id)
        {

            content? content = _context.Contents.ToList().Find(c => c.Id == id);
            if (content is null)
                return NotFound();



            return View(content);
        }




    }
}
