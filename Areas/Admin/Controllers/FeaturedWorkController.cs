using FrontToBacktask2.Areas.Admin.ViewModels.FeaturedWork;
using FrontToBacktask2.Areas.Admin.ViewModels.ServiceComponent;
using FrontToBacktask2.DAL;
using FrontToBacktask2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask2.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class FeaturedWorkController : Controller
    {
        private readonly AppDbContext _context;

        public FeaturedWorkController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var featuredWorks = _context.FeaturedWorks.OrderByDescending(fw => fw.Id).ToList();

            FeaturedWorkIndexVM model = new FeaturedWorkIndexVM()
            {
                FeaturedWorks = featuredWorks
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeaturecWorkCreateVM model)
        {
            if (ModelState.IsValid) return View();

            var featuredWork = new FeaturedWork
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Description = model.Description,
            };

            var dbFeaturedWork = _context.FeaturedWorks.FirstOrDefault(x => !x.IsDeleted);
            if (dbFeaturedWork != null)
            {
            dbFeaturedWork.IsDeleted = true;
            _context.FeaturedWorks.Update(featuredWork);
            }

            _context.FeaturedWorks.Add(featuredWork);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            var featuredWork = _context.FeaturedWorks.Find(id);

            var model = new FeaturedWorkDetailsVM
            {
                Title = featuredWork.Title,
                Subtitle = featuredWork.Subtitle,
                Description = featuredWork.Description,
            };
            return View(model); 
        }


    }
}
