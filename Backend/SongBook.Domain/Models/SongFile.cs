using System;

namespace SongBook.Domain.Models
{
    public class SongFile : BaseModel
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
