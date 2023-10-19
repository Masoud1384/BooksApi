using System.Drawing;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishDate { get; private set; }
        public Author author { get; set; }

        public Book()
        {
            
        }

        public Book(string name, string description, DateTime publishDate)
        {
            Name = name;
            Description = description;
            PublishDate = publishDate;
        }

        public Book(string name, string description, DateTime publishDate, Author author) : this(name, description, publishDate)
        {
            this.author = author;
        }
    }
}
