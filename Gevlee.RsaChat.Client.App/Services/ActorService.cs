using System;
using Akka.Actor;
using Akka.DI;
using Akka.DI.Core;

namespace Gevlee.RsaChat.Client.App.Services
{
	public class ActorService : IActorService
	{
		private readonly ActorSystem system;

		public ActorService(ActorSystem system)
		{
			this.system = system;
		}

		public IActorRef GetActor(string name)
		{
			return system.ActorSelection(name.Contains("/") ? name : $"../{name}").ResolveOne(TimeSpan.MaxValue).Result;
		}

		public IActorRef CreateActor<T>(string name) where T : ActorBase
		{
			return system.ActorOf(system.DI().Props<T>(), name);
		}
	}
}