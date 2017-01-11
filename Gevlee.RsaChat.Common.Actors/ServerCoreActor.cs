using System;
using Akka.Actor;

namespace Gevlee.RsaChat.Common.Actors
{
	public class ServerCoreActor : ReceiveActor
	{
		public ServerCoreActor()
		{
			Receive<string>(s =>
			{
				Console.WriteLine("s");
			});
		}

		protected override void PreStart()
		{
			Console.WriteLine($"[{Self.Path}] - pre start");
			base.PreStart();
		}
	}
}