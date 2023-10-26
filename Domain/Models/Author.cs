namespace Domain.Models
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool Active { get; private set; }
        public List<Book>? books { get; set; }
        public void Activate()
        {
            if (!this.Active)
                this.Active = true;
        }
        public void DeActive()
        {
            if (this.Active)
                this.Active = false;
        }
        public Author()
        {

        }
        public Author(string name ,int age, List<Book>? books)
        {
            Name = name;
            Age = age;
            this.books = books;
            Active = true;
        }
    }
}
