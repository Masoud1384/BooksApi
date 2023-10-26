using Application.Commands.Books;

namespace Application.Commands.Authors
{
    public class CreateAuthorCommand
    {
        public string Name { get;  set; }
        public bool Active { get; set; }
        public int Age { get; set; }
        public List<BookViewModel> booksVm { get; set; }
        public CreateAuthorCommand()
        {
            
        }

        public CreateAuthorCommand(string name,bool active, int age, List<BookViewModel> booksVm)
        {
            Name = name;
            Age = age;
            this.booksVm = booksVm;
            this.Active = active;
        }
    }
}
