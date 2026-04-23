using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.MVC.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly IPurchaseService _purchaseService;
private readonly IGenreService _genreService;

    public MoviesController(IMovieService movieService, IPurchaseService purchaseService, IGenreService genreService)
    {
        _movieService = movieService;
        _purchaseService = purchaseService;
        _genreService = genreService;
    }

   

  public async Task<IActionResult> Details(int id)
{
    var movie = await _movieService.GetMovieDetails(id);
    if (movie == null)
{
    return NotFound(); 
}
    // URL se userId nikalna
    int userId = 0;
    if (int.TryParse(Request.Query["userId"], out int idValue))
    {
        userId = idValue;
    }

    bool isPurchased = false;
    // Agar user logged in hai (userId > 0), toh check karein
    if (userId > 0)
    {
        isPurchased = await _purchaseService.IsMoviePurchased(userId, id);
    }

    // Isse View ko pata chalega ki button kaunsa dikhana hai
    ViewBag.IsPurchased = isPurchased;

    return View(movie);
}

[HttpPost]
public async Task<IActionResult> Purchase(int id, int userId) 
{
    var movie = await _movieService.GetMovieDetails(id);

    var purchaseRequest = new PurchaseRequestModel 
    {
        MovieId = id,
        UserId = userId, // Parameter se aayi hui ID
        TotalPrice = movie.Price
    };

    await _purchaseService.PurchaseMovie(purchaseRequest);
    return RedirectToAction("Purchases", "User", new { userId = userId });
}



[HttpGet]
public async Task<IActionResult> Genre(int id, int pageNumber = 1)
{

    var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, 30, pageNumber);
var genre = await _genreService.GetGenreById(id);

    string genreName = genre != null ? genre.Name : "Movies";

    ViewBag.GenreId = id;
    ViewBag.GenreName = genreName; 

    return View("Index", pagedMovies);
}
}