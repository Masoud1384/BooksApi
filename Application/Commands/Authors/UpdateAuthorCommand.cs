using Application.Commands.Books;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommand : CreateAuthorCommand
    {
        public int id { get; set; }
        public UpdateAuthorCommand()
        {

        }

        public UpdateAuthorCommand(int id, string name, string nationality, string? biography, int age, List<BookViewModel> booksVm)
            : base(name, nationality, biography, age, booksVm)
        {
            this.id = id;
        }
    }
}
