using FrontToBacktask2.Areas.Admin.ViewModels.WorkCategory;
using FrontToBacktask2.DAL;
using FrontToBacktask2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public WorkCategoryController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult Index()
        {
            var model = new WorkCategoryIndexVM
            {
                WorkCategories = _context.WorkCategories.OrderByDescending(wc => wc.Id).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(WorkCategoryCreateVM model)
        {
            if (!ModelState.IsValid) return View();

            var workCategory = new WorkCategory
            {
                Name = model.Name,
                CreatedAt = DateTime.Now
            };

            var dbWorkCategory = _context.WorkCategories.FirstOrDefault(wc => !wc.IsDeleted);
            dbWorkCategory.IsDeleted = true;
            _context.WorkCategories.Update(workCategory);

            _context.WorkCategories.Add(workCategory);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

