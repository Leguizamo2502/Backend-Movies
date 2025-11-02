using Entity.Domain.Models.Implements.Auth;
using Entity.Domain.Models.Implements.Catalog;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Domain.Models.Implements.Talent;
using Entity.Domain.Models.Implements.Watchlists;
using Microsoft.EntityFrameworkCore;

namespace Entity.Infrastructure.Contexs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }

        //DbSet
        public DbSet<User> Users => Set<User>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
        public DbSet<Watchlist> Watchlists => Set<Watchlist>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<MovieActor> MovieActors { get; set; }
    }
}
