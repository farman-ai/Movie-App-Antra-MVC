using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}