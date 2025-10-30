using LibraryManagament.Application.Interfaces;
using LibraryManagament.Domain.Interfaces;
using LibraryManagament.Domain.Models;

namespace LibraryManagament.Application.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author AddAuthor(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name)) throw new ArgumentException("У автора должно быть имя!!!");


            if (author.DateOfBirth >= DateTime.Now) throw new ArgumentException("Автор не может родиться в будущем!!!");

            _authorRepository.AddAuthor(author);
            return author;
        }
        public void DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);
            if (author == null) throw new ArgumentException("Автор не существует");
            _authorRepository.DeleteAuthor(id);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public Author GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);
            if ( author == null) throw new ArgumentException("Автора не существуте");
            return author;
        }

        public IEnumerable<Author> GetAuthorsContains(string namePart)
        {
            return _authorRepository.GetAuthorsContains(namePart);
        }
        public IEnumerable<Author> GetAuthorsBornAfter(DateTime date) {
           
            return _authorRepository.GetAuthorsBornAfter(date); 
        
        }


        public Author UpdateAuthor(int id, Author author)
        {
            var existing = _authorRepository.GetAuthor(id);
            if (existing == null) throw new ArgumentException("Автора не существуте");


            if (string.IsNullOrWhiteSpace(author.Name)) throw new ArgumentException("У автора должно быть имя!!!");

            if (author.DateOfBirth > DateTime.Now) throw new ArgumentException("Автор не может родиться в будущем!!!");


            _authorRepository.UpdateAuthor(id, author.Name, author.DateOfBirth);
            return author;
        }
    }
}
