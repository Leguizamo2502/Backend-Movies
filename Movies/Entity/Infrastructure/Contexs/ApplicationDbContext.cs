using Entity.Domain.Models.Implements.Auth;
using Entity.Domain.Models.Implements.Catalog;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Domain.Models.Implements.Talent;
using Entity.Domain.Models.Implements.Watchlists;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Entity.Infrastructure.Contexs
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _http;

        public ApplicationDbContext(
             DbContextOptions<ApplicationDbContext> options,
             IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor
         ) : base(options)
        {
            _configuration = configuration;
            _http = httpContextAccessor;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        //DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
