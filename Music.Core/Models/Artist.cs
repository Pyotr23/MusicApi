using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Music.Core.Models
{
    public class Artist
    {
        public Artist()
        {
            Songs = new Collection<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
