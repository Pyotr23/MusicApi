using Microsoft.EntityFrameworkCore;
using Music.Core.Models;
using Music.Data.Configurations;

namespace Music.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new SongConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
