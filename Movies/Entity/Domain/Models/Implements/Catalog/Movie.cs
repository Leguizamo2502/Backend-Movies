using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Domain.Models.Implements.Talent;
using Entity.Domain.Models.Implements.Watchlists;

namespace Entity.Domain.Models.Implements.Catalog
{
    public class Movie : BaseModel
    {
        public string Title { get; set; } = null!;
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Description { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<MovieGenre> MovieGenres { get; set; } = [];
        public ICollection<Watchlist> Watchlists { get; set; } = [];
        public ICollection<MovieActor> MovieActors { get; set; } = [];
    }
}
