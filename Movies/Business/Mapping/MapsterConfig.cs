using Entity.Domain.Models.Implements.Catalog;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Domain.Models.Implements.Talent;
using Entity.Domain.Models.Implements.Watchlists;
using Entity.DTOs.Catalog.MovieGenre.Select;
using Entity.DTOs.Reviews.Select;
using Entity.DTOs.Talent.MovieActor.Select;
using Entity.DTOs.Watchlists.Select;
using Mapster;

namespace Business.Mapping
{
    public static class MapsterConfig
    {
        public static TypeAdapterConfig Register()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.NewConfig<MovieGenre, MovieGenreSelectDto>()
                .Map(dest => dest.Title, src => src.Movie.Title)
                .Map(dest => dest.GenreName, src => src.Genre.Name);

            config.NewConfig<Review, ReviewSelectDto>()
                .Map(dest => dest.Title, src => src.Movie.Title);

            config.NewConfig<Watchlist, WatchlistSelectDto>()
                .Map(dest => dest.Title, src => src.Movie.Title);

            config.NewConfig<MovieActor, MovieActorSelectDto>()
                .Map(dest => dest.Title, src => src.Movie.Title);

            return config;
        }
    }
}
