using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers;

public class MoviesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}