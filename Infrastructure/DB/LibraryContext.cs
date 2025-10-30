using LibraryManagament.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagament.Infrastructure.DB
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>().HasData(

                    new Author { Id = 1, Name = "Jesse Pinkman", DateOfBirth = new DateTime(1991, 06, 12) },
                    new Author { Id = 2, Name = "Walter White", DateOfBirth = new DateTime(1979, 02, 28) },
                    new Author { Id = 3, Name = "Mike Ermenthrout", DateOfBirth = new DateTime(1968, 11, 10) }

                );
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Title = "Breaking Bad Story", PublishedYear = 2008, AuthorId = 1 },
                    new Book { Id = 2, Title = "Chemistry for Fun", PublishedYear = 2009, AuthorId = 2 },
                    new Book { Id = 3, Title = "Innowise secrets", PublishedYear = 2010, AuthorId = 3 },
                    new Book { Id = 6, Title = "Advanced Chemistry", PublishedYear = 2013, AuthorId = 2 },
                    new Book { Id = 7, Title = "El Camino", PublishedYear = 2014, AuthorId = 1 }
    );



        }
    }
}
