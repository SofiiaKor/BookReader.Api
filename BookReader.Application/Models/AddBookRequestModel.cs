namespace BookReader.Application.Models
{
    public class AddBookRequestModel
    {
        public string Name { get; set; }

        public string Author { get; set; }
        
        public int Year { get; set; }

        public string Publisher { get; set; }

        public int NumberOfPages { get; set; }
    }
}
