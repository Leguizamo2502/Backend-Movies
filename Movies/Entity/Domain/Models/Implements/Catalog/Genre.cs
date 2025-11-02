using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements.Catalog
{
    public class Genre : BaseModel
    {
        public string Name { get; set; } = null!;

        public ICollection<MovieGenre> MovieGenres { get; set; } = [];
    }
}
