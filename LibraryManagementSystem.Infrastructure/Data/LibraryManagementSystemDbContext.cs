using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class LibraryManagementSystemDbContext:DbContext
    {
        public LibraryManagementSystemDbContext(DbContextOptions<LibraryManagementSystemDbContext> options):base(options) { }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "JahirStory", ISBN = "JA0209320092", Genre = Genre.Biography, Pages = 255, PublicationYear = 2026, IsAvailable = true, AddedDate = new DateTime(2026, 01, 01) },
                new Book { Id = 2, Title = "Dungeons of Doom", ISBN = "DO0209320092", Genre = Genre.SciFi, Pages = 5025, PublicationYear = 2026, IsAvailable = true, AddedDate = new DateTime(2026, 01, 01) }
                );
        }
    }
}
