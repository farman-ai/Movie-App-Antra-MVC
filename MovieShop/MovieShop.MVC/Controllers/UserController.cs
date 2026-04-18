using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}