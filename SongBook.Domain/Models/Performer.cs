using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Performer : ModelBase
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
    }
}
