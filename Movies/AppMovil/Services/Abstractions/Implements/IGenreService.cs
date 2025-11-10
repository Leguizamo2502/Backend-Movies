using AppMovil.Models.Implements.Genre;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements
{
    public interface IGenreService : IGenericService<GenreSelectDto,GenreCreateDto,GenreUpdateDto>
    {
    }
}
