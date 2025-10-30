using LibraryManagament.Domain.Interfaces;
using LibraryManagament.Domain.Models;
using LibraryManagament.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagament.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }
        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = GetAuthor(id);
            if (author != null)
                _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors;
        }

        public Author? GetAuthor(int id)
        {

            return _context.Authors
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Id == id);

        }
        public IEnumerable<Author> GetAuthorsBornAfter(DateTime date)
        {
            return _context.Authors
                .Where(a => a.DateOfBirth > date)
                .Include(a => a.Books)
                .ToList();
        }

        public IEnumerable<Author> GetAuthorsContains(string namePart)
        {   if (string.IsNullOrWhiteSpace(namePart)) return new List<Author>();

            else return _context.Authors.Where(a => a.Name.Contains(namePart)).Include(b => b.Books).ToList();
        }

        public void UpdateAuthor(int id, string newName, DateTime? newDateOfBirth)
        {
            var author = GetAuthor(id);
            if (author != null)
            {
                author.Name = newName;
                author.DateOfBirth = newDateOfBirth;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Автор с таким Id не найден");
            }
        }
    }
}
