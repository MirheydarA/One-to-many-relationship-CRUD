using FrontToBacktask2.DAL;
using FrontToBacktask2.ViewModels.About;
using FrontToBacktask2.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask2.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contactcreating = _context.ContactCreatings.FirstOrDefault(c => !c.IsDeleted);

            var contacttypes = _context.ContactTypes.OrderByDescending(ct => !ct.IsDeleted2).ToList();     ////////

            var model = new ContactIndexViewModel
            {
                ContactCreating = contactcreating,
                ContactTypes = contacttypes
            };

            


            return View(model);
        }
    }
}
