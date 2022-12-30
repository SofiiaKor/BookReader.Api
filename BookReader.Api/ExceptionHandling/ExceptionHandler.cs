using System.IO;
using System.Threading.Tasks;
using BookReader.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookReader.Api.ExceptionHandling
{
	public class ExceptionHandler : DbContext, IExceptionHandler
	{
		private readonly StreamWriter _errorStream = new("../errors.txt", append: true);

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.LogTo(_errorStream.WriteLine);

		public void WriteToFile(string info)
		{
			_errorStream.Write(info + "\n");
		}

		public override void Dispose()
		{
			_errorStream.Close();

			base.Dispose();
			_errorStream.Dispose();
		}

		public override async ValueTask DisposeAsync()
		{
			await base.DisposeAsync();
			await _errorStream.DisposeAsync();
		}
    }
}
