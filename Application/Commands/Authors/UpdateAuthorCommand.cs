using Application.Commands.Books;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommand : CreateAuthorCommand
    {
        public int id { get; set; }
        public UpdateAuthorCommand()
        {

        }

        public UpdateAuthorCommand(int id, string name, bool active, int age, List<BookViewModel> booksVm)
            : base(name, active, age, booksVm)
        {
            this.id = id;
        }
    }
}
