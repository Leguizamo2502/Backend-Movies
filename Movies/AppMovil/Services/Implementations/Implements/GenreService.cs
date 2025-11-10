using AppMovil.Models.Implements.Genre;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements
{
    internal class GenreService : GenericService<GenreSelectDto, GenreCreateDto, GenreUpdateDto>, IGenreService
    {
        public GenreService(ApiClient api) : base(api, "Genre")
        {
        }
    }
}
