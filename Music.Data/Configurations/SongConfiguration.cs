using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Core.Models;

namespace Music.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        private const string TableName = "Songs";
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId);

            builder
                .ToTable(TableName);
        }
    }
}
