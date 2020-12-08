using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music.Api.Resources;
using Music.Api.Validators;
using Music.Core.Models;
using Music.Core.Services;

namespace Music.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Получение всех песен.
        /// </summary>
        /// <returns> Результат запроса со списком песен. </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongResource>>> GetAllSongs()
        {
            var songs = await _songService.GetAllWithArtist();
            var songResources = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResource>>(songs);
            return Ok(songResources);
        }

        /// <summary>
        ///     Получить песню по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор песни </param>
        /// <returns> Результат запроса с песней. </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SongResource>> GetSongById(int id)
        {
            var song = await _songService.GetSongById(id);
            var songResource = _mapper.Map<Song, SongResource>(song);
            return Ok(songResource);
        }

        [HttpPost]
        public async Task<ActionResult<SongResource>> CreateSong([FromBody] SaveSongResource saveSongResource)
        {
            var validator = new SaveSongResourceValidator();
            var validationResult = await validator.ValidateAsync(saveSongResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var songToCreate = _mapper.Map<SaveSongResource, Song>(saveSongResource);
            var newSong = _songService.CreateSong(songToCreate);
            var song = await _songService.GetSongById(newSong.Id);
            var songResource = _mapper.Map<Song, SongResource>(song);
            return Ok(songResource);
        }
    }
}
