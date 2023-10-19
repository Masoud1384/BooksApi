using Application.Commands.Books;

namespace Application.Commands.Authors
{
    public class CreateAuthorCommand
    {
        public string Name { get; private set; }
        public string Nationality { get; set; }
        public string? Biography { get; set; }
        public int Age { get; set; }
        public List<BookViewModel> booksVm { get; set; }
        public CreateAuthorCommand()
        {
            
        }

        public CreateAuthorCommand(string name, string nationality, string? biography, int age, List<BookViewModel> booksVm)
        {
            Name = name;
            Nationality = nationality;
            Biography = biography;
            Age = age;
            this.booksVm = booksVm;
        }
    }
}
