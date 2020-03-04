using Microsoft.EntityFrameworkCore;
using SongBook.Repo.Configurations;

namespace SongBook.Repo
{
    public class SongBookDbContext : DbContext
    {
        public SongBookDbContext(DbContextOptions<SongBookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ChordConfiguration());
            builder.ApplyConfiguration(new DescriptionConfiguration());
            builder.ApplyConfiguration(new LineChordConfiguration());
            builder.ApplyConfiguration(new LineConfiguration());
            builder.ApplyConfiguration(new ParagraphConfiguration());
            builder.ApplyConfiguration(new PerformerConfiguration());
            builder.ApplyConfiguration(new SongConfiguration());
        }
    }
}
