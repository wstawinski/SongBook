﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongBook.Repo;

namespace SongBook.Repo.Migrations
{
    [DbContext(typeof(SongBookDbContext))]
    [Migration("20200304194646_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SongBook.Domain.Models.Chord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChordSchema")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chords");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Description", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Line", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<long?>("ParagraphId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SongBook.Domain.Models.LineChord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ChordId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LineId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ChordId");

                    b.HasIndex("LineId");

                    b.ToTable("LineChords");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Paragraph", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<long?>("SongId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Performer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Performers");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("PerformerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PerformerId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Description", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Song", null)
                        .WithOne("Description")
                        .HasForeignKey("SongBook.Domain.Models.Description", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SongBook.Domain.Models.Line", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Paragraph", null)
                        .WithMany("Lines")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SongBook.Domain.Models.LineChord", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Chord", "Chord")
                        .WithMany()
                        .HasForeignKey("ChordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SongBook.Domain.Models.Line", null)
                        .WithMany("LineChords")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SongBook.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Song", null)
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SongBook.Domain.Models.Song", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Performer", "Performer")
                        .WithMany("Songs")
                        .HasForeignKey("PerformerId");
                });
#pragma warning restore 612, 618
        }
    }
}
