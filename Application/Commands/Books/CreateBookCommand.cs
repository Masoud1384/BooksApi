namespace Application.Commands.Books
{
    public class CreateBookCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishDate { get; private set; }

        public CreateBookCommand()
        {
            
        }

        public CreateBookCommand(string name, string description, DateTime publishDate)
        {
            Name = name;
            Description = description;
            PublishDate = publishDate;
        }
    }
}
