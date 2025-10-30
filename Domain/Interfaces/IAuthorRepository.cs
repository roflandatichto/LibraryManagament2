using LibraryManagament.Domain.Models;

namespace LibraryManagament.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        void DeleteAuthor(int id);
        Author? GetAuthor(int id);
        void UpdateAuthor(int id, string newName, DateTime? newDateOfBirth);
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Author> GetAuthorsContains(string namePart);
        IEnumerable<Author> GetAuthorsBornAfter(DateTime date);
    } 
}

