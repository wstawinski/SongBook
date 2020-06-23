using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Models;

namespace SongBook.Repo
{
    public class SongBookDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Chord> Chords { get; set; }

        public SongBookDbContext(DbContextOptions<SongBookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasMany(s => s.Paragraphs)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paragraph>()
                .HasMany(p => p.Lines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Paragraph>()
                .ToTable(nameof(Song.Paragraphs));

            modelBuilder.Entity<Line>()
                .HasMany(l => l.Words)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Line>()
                .ToTable(nameof(Paragraph.Lines));

            modelBuilder.Entity<Word>()
                .HasOne(w => w.Chord)
                .WithMany();
        }
    }
}
