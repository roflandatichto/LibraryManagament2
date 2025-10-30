namespace LibraryManagament.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
