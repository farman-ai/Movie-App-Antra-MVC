using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.Infrastructure.Services;

public class MovieService : IMovieService
{
    public IEnumerable<MovieCardModel> GetTopMovies()
    {
       return new List<MovieCardModel>
{
    new MovieCardModel
    {
        Id = 1,
        Title = "Domestic Disturbance",
        PosterUrl = "https://image.tmdb.org/t/p/w342/jdGniF19AqQ1taLXmK04b6BjQk.jpg",
        Rating = 7.4m
    },
    new MovieCardModel
    {
        Id = 2,
        Title = "The Hard Way",
        PosterUrl = "https://image.tmdb.org/t/p/w342/1Nu42swt2QbHGV5o69UJL9EaprJ.jpg",
        Rating = 7.1m
    },
    new MovieCardModel
    {
        Id = 3,
        Title = "Death to Smoochy",
        PosterUrl = "https://image.tmdb.org/t/p/w342/jLOgkwcXzlCmwjbWVaWS1vETutl.jpg",
        Rating = 6.8m
    },
    new MovieCardModel
    {
        Id = 4,
        Title = "Sweet Smell of Success",
        PosterUrl = "https://image.tmdb.org/t/p/w342/7xfLUISDZ1zZ8vPU5Y7j5mv0Xvc.jpg",
        Rating = 8.1m
    },
    new MovieCardModel
    {
        Id = 5,
        Title = "Trauma Center",
        PosterUrl = "https://image.tmdb.org/t/p/w342/8K73wvCTBA3XKgZTtOZWgENUnis.jpg",
        Rating = 5.9m
    },
    new MovieCardModel
    {
        Id = 6,
        Title = "Shimmer Lake",
        PosterUrl = "https://image.tmdb.org/t/p/w342/bQHhpTHiys0CZRrdDRKvXBmM5KL.jpg",
        Rating = 6.3m
    },
    new MovieCardModel
    {
        Id = 7,
        Title = "City of Lies",
        PosterUrl = "https://image.tmdb.org/t/p/w342/pK7IYQdtdWtMDBJZfMqDxgMjXEt.jpg",
        Rating = 6.5m
    },
    new MovieCardModel
    {
        Id = 8,
        Title = "War Room",
        PosterUrl = "https://image.tmdb.org/t/p/w342/unxQeVUi5DH01r7ZNvAHwpvX7UK.jpg",
        Rating = 6.9m
    }

        };
    }
}