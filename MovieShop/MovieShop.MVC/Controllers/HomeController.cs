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

    public IActionResult TopMovies()
    {
        var movies = _movieService.GetTopMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    // public async Task<IActionResult> Index()
    // {
    //     var movies = await _movieService.GetHighestGrossingMovies();
    //     return View(movies);
    // }

public async Task<IActionResult> Index(int pageNumber = 1)
{
    int pageSize = 18; // Ek page pe 30 movies dikhayenge
    var pagedMovies = await _movieService.GetMoviesByPagination(pageNumber, pageSize);
    return View(pagedMovies);
}
}