using Music.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Core.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<IEnumerable<Song>> GetAllWithArtistAsync();
        Task<Song> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Song>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
