using Akka.Actor;
using Gevlee.RsaChat.Common.Messages;

namespace Gevlee.RsaChat.Common.Actors
{
	public class ClientCoreActor : ReceiveActor
	{
		public ClientCoreActor()
		{
			Receive<ServerConnection>(connection =>
			{
				var serverCore = Context.ActorSelection("akka.tcp://RsaChatSystem@localhost:8998/user/core");
				serverCore.Tell("Hello my friend");
			});
		}
	}
}