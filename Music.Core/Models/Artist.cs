using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Music.Core.Models
{
    public class Artist
    {
        public Artist()
        {
            Musics = new Collection<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Musics { get; set; }
    }
}
