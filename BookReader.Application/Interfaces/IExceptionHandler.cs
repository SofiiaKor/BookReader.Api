using System.Threading.Tasks;

namespace BookReader.Application.Interfaces
{
	public interface IExceptionHandler
	{
		void WriteToFile(string info);

		void Dispose();

		ValueTask DisposeAsync();
	}
}
