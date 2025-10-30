using LibraryManagament.Application.Interfaces;
using LibraryManagament.Domain.Interfaces;
using LibraryManagament.Domain.Models;

namespace LibraryManagament.Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public Book AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("У книги должно быть название!");

            if (book.PublishedYear > DateTime.Now.Year)
                throw new ArgumentException("Книга не может быть написана в будущем!");

            var author = _authorRepository.GetAuthor(book.AuthorId);
            if (author == null)
                throw new ArgumentException("Автор с таким id не существует!");

            _bookRepository.AddBook(book);
            return book;
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if (book == null)
                throw new ArgumentException("Книга не найдена!");

            _bookRepository.DeleteBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {

            return _bookRepository.GetAllBooks();

        }
        public IEnumerable<Book> GetAllBooks(int? AuthorId)
        {

            return _bookRepository.GetAllBooks(AuthorId);

        }

        public Book GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if (book == null)
                throw new ArgumentException("Книга не найдена!");
            return book;
        }


        public Book UpdateBook(int id, Book book)
        {
            var existing = _bookRepository.GetBook(id);
            if (existing == null)
                throw new ArgumentException("Книга не найдена!");

            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("У книги должно быть название!");

            if (book.PublishedYear < 1450 || book.PublishedYear > DateTime.Now.Year)
                throw new ArgumentException("Некорректный год публикации!");

            var author = _authorRepository.GetAuthor(book.AuthorId);
            if (author == null)
                throw new ArgumentException("Автор с таким ID не существует!");

            _bookRepository.UpdateBook(id, book.Title, book.PublishedYear, book.AuthorId);
            return book;
        }
        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return _bookRepository.GetBooksByTitle(title);
        }

        public IEnumerable<Book> GetBooksPublishedAfter(int year)
        {
            return _bookRepository.GetBooksPublishedAfter(year);
        }

    }
}
