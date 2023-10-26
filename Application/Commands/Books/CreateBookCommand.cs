using Application.Commands.Authors;

namespace Application.Commands.Books
{
    public class CreateBookCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int authorId { get; set; }


        public CreateBookCommand()
        {

        }

        public CreateBookCommand(string name, string description, DateTime publishDate)
        {
            Name = name;
            Description = description;
            PublishDate = publishDate;
        }
        public CreateBookCommand(string name, string description, DateTime publishDate, int authorId)
            : this(name, description, publishDate)
        {
            this.authorId = authorId;
        }
    }
}
