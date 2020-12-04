using Microsoft.EntityFrameworkCore;
using Music.Core.Models;
using Music.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Artist>> GetAllWithSongsAsync()
        {
            return await _dbSet
                .Include(a => a.Songs)
                .ToListAsync();
        }

        public async Task<Artist> GetWithSongsByIdAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Songs)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
