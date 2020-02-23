using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs");
            builder.HasKey(s => s.Id);

            builder.OwnsMany(s => s.Paragraphs, p =>
            {
                p.ToTable("Paragraphs");
                p.HasKey(p => p.Id);
                p.Ignore(p => p.IsDeleted);

                p.OwnsMany(p => p.Lines, l =>
                {
                    l.ToTable("Lines");
                    l.HasKey(l => l.Id);
                    l.Ignore(l => l.IsDeleted);

                    l.OwnsMany(l => l.LineChords, lc =>
                    {
                        lc.ToTable("LineChords");
                        lc.HasKey(lc => lc.Id);
                        lc.Ignore(lc => lc.IsDeleted);

                        lc.HasOne(lc => lc.Chord);
                    });
                });
            });

            builder.OwnsOne(s => s.PerformerDescription);
            builder.OwnsOne(s => s.UserDescription);
        }
    }
}
