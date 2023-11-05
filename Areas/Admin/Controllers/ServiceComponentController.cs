using FrontToBacktask2.Areas.Admin.ViewModels.ServiceComponent;
using FrontToBacktask2.DAL;
using FrontToBacktask2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask2.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class ServiceComponentController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceComponentController(AppDbContext context)
        {
            _context = context;
        }
        #region Index

        [HttpGet]                                                   /////////////////////
        public IActionResult Index()
        {
            var serviceComponents = _context.ServiceComponents.OrderByDescending(sc => sc.Id).ToList();
            var model = new ServiceComponentIndexVM
            {
                ServiceComponents = serviceComponents
            };
            return View(model);                                     ///////////////////
        }
        #endregion

        #region Create 

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceComponentCreateVM model) 
        { 
            if (ModelState.IsValid) return View();

            var serviceComponent = new ServiceComponent
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Description = model.Description,
            };

            var dbServiceComponent = _context.ServiceComponents.FirstOrDefault(x => !x.IsDeleted);
            dbServiceComponent.IsDeleted = true;
            _context.ServiceComponents.Update(serviceComponent);

            _context.ServiceComponents.Add(serviceComponent);
            _context.SaveChanges();

            return RedirectToAction("Index");   
        }

        #endregion


        #region Details
        [HttpGet]
        public IActionResult Details(int id) 
        {
            var serviceComponent = _context.ServiceComponents.Find(id);

            var model = new ServiceComponentDetailsVM
            {
                Title = serviceComponent.Title,
                Subtitle = serviceComponent.Subtitle,
                Description = serviceComponent.Description,
            };
            return View(model);
        }

        #endregion
    }
}
