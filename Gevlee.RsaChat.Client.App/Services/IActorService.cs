using Akka.Actor;

namespace Gevlee.RsaChat.Client.App.Services
{
	public interface IActorService
	{
		IActorRef GetActor(string name);
		IActorRef CreateActor<T>(string name) where T : ActorBase;
	}
}