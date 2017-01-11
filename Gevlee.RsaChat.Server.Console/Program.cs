using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Gevlee.RsaChat.Common.Actors;

namespace Gevlee.RsaChat.Server.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var system = ActorSystem.Create("RsaChatSystem");
			system.ActorOf(Props.Create<ServerCoreActor>(), "core");
			System.Console.ReadKey();
		}
	}
}
