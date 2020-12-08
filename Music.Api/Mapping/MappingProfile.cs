using AutoMapper;
using Music.Api.Resources;
using Music.Core.Models;

namespace Music.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongResource>();
            CreateMap<Artist, ArtistResource>();

            CreateMap<SongResource, Song>();
            CreateMap<ArtistResource, Artist>();

            CreateMap<SaveSongResource, Song>();
            CreateMap<SaveArtistResource, Artist>();
        }
    }
}
