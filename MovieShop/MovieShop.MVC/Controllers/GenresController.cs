using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class GenresController : Controller
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var genres = await _genreService.GetAllGenres();
        return View(genres);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var genre = await _genreService.GetGenreById(id);
        if (genre == null)
        {
            return NotFound();
        }

        return View(genre);
    }
}