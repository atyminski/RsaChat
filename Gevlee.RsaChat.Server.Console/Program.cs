using System;
using ColoredConsole;

namespace Gevlee.RsaChat.Server.Console
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ColorConsole.WriteLine(new ColorToken("It works!", ConsoleColor.Green));
			System.Console.ReadKey();
		}
	}
}
