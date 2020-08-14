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

            modelBuilder.Entity<User>()
                .HasData(new List<User>
                {
                    new User
                    {
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "FirstName2",
                        LastName = "LastName2"
                    }
                });

            modelBuilder.Entity<IdeaTeamMember>()
                .HasData(new List<IdeaTeamMember>
                {
                    new IdeaTeamMember
                    {
                        Id = 1,
                        UserId = 1,
                        Rate = 10
                    },
                    new IdeaTeamMember
                    {
                        Id = 2,
                        UserId = 2,
                        Rate = 10
                    },
                    new IdeaTeamMember
                    {
                        Id = 3,
                        UserId = 1,
                        Rate = 10
                    },
                    new IdeaTeamMember
                    {
                        Id = 4,
                        UserId = 2,
                        Rate = 10
                    }
                });

            modelBuilder.Entity<Question>()
                .HasData(new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        UserId = 1,
                        Content = "Content1User1"
                    },
                    new Question
                    {
                        Id = 2,
                        UserId = 2,
                        Content = "Content1User2"
                    },
                    new Question
                    {
                        Id = 3,
                        UserId = 1,
                        Content = "Content2User1"
                    },
                    new Question
                    {
                        Id = 4,
                        UserId = 2,
                        Content = "Content2User2"
                    }
                });

            modelBuilder.Entity<Idea>()
                .HasData(new List<Idea>
                {
                    new Idea
                    {
                        Id = 1,
                        Name = "Name1",
                        Description = "Description1",
                        UserId = 1
                    },
                    new Idea
                    {
                        Id = 2,
                        Name = "Name2",
                        Description = "Description2",
                        UserId = 2
                    }
                });
        }
    }
}
