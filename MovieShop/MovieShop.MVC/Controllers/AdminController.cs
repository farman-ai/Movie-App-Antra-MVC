using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.MVC.Controllers;

public class AdminController : Controller
{
    private readonly IPurchaseService _purchaseService;

    public AdminController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }
   public IActionResult Index()
    {
        return View();
    }
[HttpGet]
    public async Task<IActionResult> TopMovies(DateTime? fromDate, DateTime? toDate)
    {
        // Default values for UI inputs
        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

        var movies = await _purchaseService.GetTopMovies(fromDate, toDate);
        return View(movies);
    }
    public IActionResult CreateMovie()
    {
        // Movie add karne wala page
        return View();
    }
}