namespace Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public List<Book>? books { get; set; }

        public Author()
        {
            
        }
        public Author( string name, List<Book>? books)
        {
            Name = name;
            this.books = books;
        }
    }
}
