using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Models;
using System.Collections.Generic;

namespace SongBook.Repo
{
    public class SongBookDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Chord> Chords { get; set; }
        public DbSet<SongFile> SongFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }

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
            modelBuilder.Entity<Word>()
                .ToTable(nameof(Line.Words));

            modelBuilder.Entity<Idea>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Idea>()
                .HasMany(i => i.IdeaTeamMembers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Idea>()
               .HasMany(i => i.Questions)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IdeaTeamMember>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
