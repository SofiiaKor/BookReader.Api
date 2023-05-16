using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Application.Exceptions
{
	public class BookAlreadyExistsException : Exception
	{
		public BookAlreadyExistsException(string errorMessage) : base(errorMessage)
		{
		}
	}
}
