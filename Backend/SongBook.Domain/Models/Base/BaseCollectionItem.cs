namespace SongBook.Domain.Models
{
    public abstract class BaseCollectionItem : BaseModel
    {
        public bool IsDeleted { get; set; }
        public int Number { get; set; }
    }
}
