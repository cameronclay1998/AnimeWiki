using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AnimeGenre> AnimeGenres { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<MangaGenre> MangaGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AnimeGenre>(x => x.HasKey(ag => new {ag.AnimeId, ag.GenreId}));
            
            builder.Entity<AnimeGenre>()
                .HasOne(ag => ag.Anime)
                .WithMany(a => a.Genres)
                .HasForeignKey(ag => ag.AnimeId);
            
            builder.Entity<AnimeGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.Animes)
                .HasForeignKey(ag => ag.GenreId);
                
            builder.Entity<MangaGenre>(x => x.HasKey(mg => new {mg.MangaId, mg.GenreId}));

            builder.Entity<MangaGenre>()
                .HasOne(mg => mg.Manga)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MangaId);
            
            builder.Entity<MangaGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.Mangas)
                .HasForeignKey(mg => mg.GenreId);
        }
    }
}