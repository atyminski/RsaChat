using Gevlee.RsaChat.Server.Core;

namespace Gevlee.RsaChat.Server.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();
			System.Console.ReadKey();
		}
	}
}
