using System;

namespace BookReader.Application.Models
{
    public class BookResponseModel
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Author { get; }

        public BookResponseModel(Guid id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }
    }
}
