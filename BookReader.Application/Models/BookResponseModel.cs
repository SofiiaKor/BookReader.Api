using System;

namespace BookReader.Application.Models
{
    public class BookResponseModel
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Author { get; }

        public long ISBN { get; }

        public BookResponseModel(Guid id, string name, string author, long isbn)
        {
            Id = id;
            Name = name;
            Author = author;
            ISBN = isbn;
        }
    }
}
