using LibraryManagament.Domain.Models;

namespace LibraryManagament.Application.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        Author AddAuthor(Author author);
        Author UpdateAuthor(int id, Author author);
        void DeleteAuthor(int id);
        IEnumerable<Author> GetAuthorsContains(string namePart);
        IEnumerable<Author> GetAuthorsBornAfter(DateTime dateTime);
    }
}

