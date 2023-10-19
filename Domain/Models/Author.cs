﻿namespace Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Nationality { get; set; }
        public string? Biography { get; set; }
        public int Age { get; set; }
        public List<Book>? books { get; set; }

        public Author()
        {
            
        }

        public Author(string name, string nationality, string? biography, int age, List<Book>? books)
        {
            Name = name;
            Nationality = nationality;
            Biography = biography;
            Age = age;
            this.books = books;
        }
    }
}
