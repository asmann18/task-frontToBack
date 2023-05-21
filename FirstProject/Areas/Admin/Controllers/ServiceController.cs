using FirstProject.Contexts;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {

        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            List<content> services = _context.Contents.ToList();

            return View(services);


        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(content content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }



        public IActionResult update(int id)
        {
            content? Content = _context.Contents.ToList().Find(x => x.Id == id);
            if (Content == null)
            {
                return (NotFound());
            }

            return View(Content);
        }

        [HttpPost("update")]
        public IActionResult updateService(content content, int id)
        {
            content? Content = _context.Contents.ToList().Find(x => x.Id == id);
            if (Content == null)
            {
                return (NotFound());
            }

            _context.Contents.Remove(Content);

            _context.Contents.Add(content);
            _context.SaveChanges();
            return View();

        }
    }
}
