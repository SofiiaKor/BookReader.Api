using System;

namespace BookReader.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public int Year { get; private set; }

        public string Publisher { get; private set; }

        public int NumberOfPages { get; private set; }

        public Book(Guid id, string name, string author, int year, string publisher, int numberOfPages)
        {
            Id = id;
            Name = name;
            Author = author;
            Year = year;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
        }

        public void Update(string name, string author, int year, string publisher, int numberOfPages)
        {
	        Name = name;
	        Author = author;
	        Year = year;
	        Publisher = publisher;
	        NumberOfPages = numberOfPages;
        }
    }
}
