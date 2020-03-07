using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class ChordConfiguration : IEntityTypeConfiguration<Chord>
    {
        public void Configure(EntityTypeBuilder<Chord> builder)
        {
            builder.ToTable("Chords");

            builder.HasMany<LineChord>()
                .WithOne(lc => lc.Chord)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
