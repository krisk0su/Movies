namespace MoviesApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Actors;
    using Models.Animes;
    using Models.Categories;
    using Models.Movies;
    using Models.Series;
    
    public class MoviesAppContext : IdentityDbContext<MoviesAppUser>
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MoviesCategories> MoviesCategories { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MoviesActors> MoviesActors { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<SeriesEntity> SeriesEntity { get; set; }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<AnimeEntity> AnimeEntities { get; set; }

        public MoviesAppContext(DbContextOptions<MoviesAppContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasAlternateKey(a => a.Name);

            builder.Entity<MoviesCategories>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.MoviesCategories)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<MoviesCategories>()
                .HasOne(x => x.Category)
                .WithMany(x => x.MoviesCategories)
                .HasForeignKey(x => x.CategoryId);

            //TODO MOVIES ACTORS
                
            base.OnModelCreating(builder);
        }
    }
}
