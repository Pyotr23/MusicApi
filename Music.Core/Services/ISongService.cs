using Music.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Core.Services
{
    public interface ISongService
    {
        Task<Song> CreateSong(Song newSong);
        Task DeleteSong(Song song);
        Task<IEnumerable<Song>> GetAllWithArtist();
        Task<Song> GetSongById(int id);
        Task<IEnumerable<Song>> GetSongsByArtistId(int artistId);
        Task UpdateSong(Song songForUpdate, Song song);
    }
}
