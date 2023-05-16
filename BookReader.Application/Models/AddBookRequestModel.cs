using FluentValidation;

namespace BookReader.Application.Models
{
    public class AddBookRequestModel
    {
	    public string Name { get; set; }

        public string Author { get; set; }
        
        public int Year { get; set; }

        public string Publisher { get; set; }

        public int NumberOfPages { get; set; }

        public long ISBN { get; set; }
    }

    public class AddBookRequestValidator : AbstractValidator<AddBookRequestModel>
    {
	    public AddBookRequestValidator()
	    {
		    RuleFor(x => x.Name).NotEmpty();
	    }
    }
}
