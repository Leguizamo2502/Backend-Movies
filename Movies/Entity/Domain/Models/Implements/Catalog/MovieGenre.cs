using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements.Catalog
{
    public class MovieGenre : BaseModel
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public Movie Movie { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
    }
}
