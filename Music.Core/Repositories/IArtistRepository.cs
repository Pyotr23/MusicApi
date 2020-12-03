using Music.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithSongsAsync();
        Task<Artist> GetWithSongsByIdAsync(int id);
    }
}
