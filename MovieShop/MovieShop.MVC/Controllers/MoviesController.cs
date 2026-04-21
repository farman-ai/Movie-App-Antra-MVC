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

   

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetMovieDetails(id);
        if (movie == null) return NotFound();

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Purchase(PurchaseModel model)
    {
        if (!ModelState.IsValid)
        {
            var movie = await _movieService.GetMovieDetails(model.MovieId);
            return View("Details", movie);
        }

        await _purchaseService.SavePurchase(model);
        TempData["Message"] = "Purchase completed successfully";

        return RedirectToAction("Details", new { id = model.MovieId });
    }




[HttpGet]
public async Task<IActionResult> Genre(int id, int pageNumber = 1)
{
    // 1. Movies fetch karein
    var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, 30, pageNumber);

    // 2. Genre Name fetch karein (Dynamic banane ke liye)
    var allGenres = await _genreService.GetAllGenres();
    var currentGenre = allGenres.FirstOrDefault(g => g.Id == id);
    
    // Agar genre mil jaye toh uska naam, warna fallback "Movies"
    string genreName = currentGenre != null ? currentGenre.Name : "Movies";

    // 3. ViewBag mein data bhejein
    ViewBag.GenreId = id;
    ViewBag.GenreName = genreName; 

    return View("Index", pagedMovies);
}
}