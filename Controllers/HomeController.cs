using FrontToBacktask2.DAL;
using FrontToBacktask2.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask2.Controllers
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
            var serviceComponent = _context.ServiceComponents.FirstOrDefault(sc => !sc.IsDeleted);
            var model = new HomeIndexVM
            {
                ServiceComponent = serviceComponent
            };
            return View(model);
        }
    }
}
