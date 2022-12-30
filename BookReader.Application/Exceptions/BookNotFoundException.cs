using System;

namespace BookReader.Application.Exceptions
{
	class BookNotFoundException : Exception
	{
		public BookNotFoundException(string errorMessage) : base(errorMessage)
		{
		}
	}
}
