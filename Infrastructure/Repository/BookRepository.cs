using LibraryManagament.Domain.Interfaces;
using LibraryManagament.Domain.Models;
using LibraryManagament.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagament.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book? GetBook(int id)
        {
            return _context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }


        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Author)
                .ToList();
        }


        public IEnumerable<Book> GetAllBooks(int? AuthorId)
        {
            var query = _context.Books.Include(b => b.Author).AsQueryable();

            if (AuthorId.HasValue)
                query = query.Where(b => b.AuthorId == AuthorId.Value);

            return query.ToList();
        }


        public void UpdateBook(int id, string newTitle, int newPublishedYear, int newAuthorId)
        {
            var book = GetBook(id);
            if (book != null)
            {
                book.Title = newTitle;
                book.PublishedYear = newPublishedYear;
                book.AuthorId = newAuthorId;

                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Книга с таким Id не найдена");
            }
        }


        public IEnumerable<Book> GetBooksByTitle(string titlePart)
        {
            if (string.IsNullOrWhiteSpace(titlePart)) return new List<Book>();

            return _context.Books
                .Include(b => b.Author)
                .Where(b => b.Title.Contains(titlePart))
                .ToList();
        }

        public IEnumerable<Book> GetBooksPublishedAfter(int year)
        {
            return _context.Books
                .Include(b => b.Author)
                .Where(b => b.PublishedYear > year)
                .ToList();
        }

    }
}
