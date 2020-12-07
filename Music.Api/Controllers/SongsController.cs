using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music.Core.Models;
using Music.Core.Services;

namespace Music.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        /// <summary>
        ///     Получение всех песен с исполнителями.
        /// </summary>
        /// <returns>Список песен</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAllSongs()
        {
            var songs = await _songService.GetAllWithArtist();
            return Ok(songs);
        }


    }
}
