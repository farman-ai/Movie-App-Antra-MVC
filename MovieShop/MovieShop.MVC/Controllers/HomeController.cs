using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;

    public HomeController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public IActionResult Index()
    {
        var movies = _movieService.GetTopMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}