using Music.Core;
using Music.Core.Models;
using Music.Core.Repositories;
using Music.Core.Services;
using Music.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISongRepository _songs;

        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _songs = unitOfWork.Songs;
        }

        public async Task<Song> CreateSong(Song newSong)
        {
            await _songs.AddAsync(newSong);
            await _unitOfWork.CommitAsync();
            return newSong;
        }

        public async Task DeleteSong(Song song)
        {
            _songs.Remove(song);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Song>> GetAllWithArtist()
        {
            return await _songs.GetAllWithArtistAsync();
        }

        public async Task<Song> GetSongById(int id)
        {
            return await _songs.GetWithArtistByIdAsync(id);
        }

        public async Task<IEnumerable<Song>> GetSongsByArtistId(int artistId)
        {
            return await _songs.GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateSong(Song songForUpdate, Song song)
        {
            songForUpdate.Name = song.Name;
            songForUpdate.ArtistId = song.ArtistId;
            await _unitOfWork.CommitAsync();
        }
    }
}
