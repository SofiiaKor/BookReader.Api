using System;

namespace BookReader.Application.Exceptions
{
	public class BookNotFoundException : Exception
	{
		public BookNotFoundException(string errorMessage) : base(errorMessage)
		{
		}
	}
}
