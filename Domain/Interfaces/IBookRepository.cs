using LibraryManagament.Domain.Models;

namespace LibraryManagament.Domain.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        Book? GetBook(int id);
        void UpdateBook(int id, string newTitle, int newPublishedYear, int newAuthorId);
        IEnumerable<Book> GetAllBooks(int? AuthorId);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByTitle(string titlePart);
        IEnumerable<Book> GetBooksPublishedAfter(int year);
    }
}
