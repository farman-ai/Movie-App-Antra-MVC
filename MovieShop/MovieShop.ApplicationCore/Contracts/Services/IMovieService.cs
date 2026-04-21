namespace MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

public interface IMovieService
{
    IEnumerable<MovieCardModel> GetTopMovies();
    Task<IEnumerable<MovieCardModel>> GetHighestGrossingMovies();
    Task<MovieDetailsResponseModel?> GetMovieDetails(int id);
    Task<PagedResultSetModel<MovieCardModel>> GetMoviesByPagination(int pageNumber = 1, int pageSize = 30);
    Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1);
}