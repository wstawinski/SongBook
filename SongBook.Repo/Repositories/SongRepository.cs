using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;
using SongBook.Repo.Repositories.Base;
using System.Threading.Tasks;

namespace SongBook.Repo.Repositories
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Song> GetByIdAsync(long id)
        {
            return await GetByIdAsync(id, new string[]
            {
                nameof(Song.Performer),
                nameof(Song.Paragraphs) + "." + nameof(Paragraph.Lines) + "." + nameof(Line.LineChords) + "." + nameof(LineChord.Chord),
                nameof(Song.Description)
            });
        }
    }
}
