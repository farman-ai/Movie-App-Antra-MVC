using MovieShop.ApplicationCore.Models;

namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IMovieService
{
    IEnumerable<MovieCardModel> GetTopMovies();
}