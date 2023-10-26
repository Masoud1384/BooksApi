using System.Drawing;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishDate { get; private set; }
        public int authorId { get;private set; }
        public bool Active { get;private set; }
        public Author author { get; set; }
        public void Activate()
        {
            this.Active = true;
        }
        public void DeActive()
        {
            this.Active = false;
        }
        public Book()
        {
            
        }

        public Book(string name, string description, DateTime publishDate)
        {
            Name = name;
            Description = description;
            PublishDate = publishDate;
        }
        public Book(string name, string description, DateTime publishDate, int authorId) : this(name, description, publishDate)
        {
            this.authorId= authorId;
        }
        public Book(int id , string name , string description , DateTime publishDate,int authorId)
            :this(name,description,publishDate,authorId)
        {
            this.Id = id;
        }
    }
}
