using FrontToBacktask2.DAL;
using FrontToBacktask2.ViewModels.Work;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask2.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var workcategories = _context.WorkCategories
                .Include(x => x.Works)
                .ToList();

            var featuredWorks = _context.FeaturedWorks.FirstOrDefault(fw => !fw.IsDeleted);

            var model = new WorkIndexVm
            {
                WorkCategories = workcategories,
                FeaturedWorks = featuredWorks
            };

            return View(model);
        }
    }
}
