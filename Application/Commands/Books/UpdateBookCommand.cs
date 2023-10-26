namespace Application.Commands.Books
{
    public class UpdateBookCommand : CreateBookCommand
    {
        public int id { get; set; }
        public UpdateBookCommand()
        {

        }
        public UpdateBookCommand(int id, string name, string description, DateTime publishDate,int authorId)
            : base(name, description, publishDate,authorId)
        {
            this.id = id;
        }
    }
}
