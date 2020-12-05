using Microsoft.EntityFrameworkCore;
using Music.Core.Models;
using Music.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Data.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(DbContext context) 
            : base(context) 
        { }

        public async Task<IEnumerable<Song>> GetAllWithArtistAsync()
        {
            return await DbSet
                .Include(s => s.Artist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await DbSet
                .Include(a => a.Artist)
                .Where(a => a.ArtistId == artistId)
                .ToListAsync();
        }

        public async Task<Song> GetWithArtistByIdAsync(int id)
        {
            return await DbSet
                .Include(s => s.Artist)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
