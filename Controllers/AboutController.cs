using FrontToBacktask2.DAL;
using FrontToBacktask2.Models;
using FrontToBacktask2.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

public class AboutController : Controller
    {
    private readonly AppDbContext _context;

    public AboutController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var aboutIntroComponent = _context.AboutIntroComponents.FirstOrDefault(aic => !aic.IsDeleted);

        var model = new AboutIndexViewModel
        {
            AboutIntroComponent = aboutIntroComponent
        };

        return View(model);
        }
    }

