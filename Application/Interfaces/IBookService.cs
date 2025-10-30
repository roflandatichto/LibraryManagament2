using LibraryManagament.Domain.Models;

namespace LibraryManagament.Application.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooks(int? AuthorId);
        Book GetBook(int id);
        Book AddBook (Book Book);
        Book UpdateBook(int id, Book book);
        void DeleteBook(int id);
        IEnumerable<Book> GetBooksPublishedAfter(int year);
        IEnumerable<Book> GetBooksByTitle(string title);
    }
}
