using System;
using Akka.Actor;
using Gevlee.RsaChat.Common.Messages;

namespace Gevlee.RsaChat.Client.Actors
{
	public class ClientCoreActor : ReceiveActor
	{
		private readonly Model.ServerConnection serverConnection;
		private Action<ConnectionReference> onSuccess;

		public ClientCoreActor(Model.ServerConnection serverConnection)
		{
			this.serverConnection = serverConnection;
			Receive<ConnectionReference>(reference =>
			{
				onSuccess?.Invoke(reference);
			});

			Receive<ServerConnection>(connection =>
			{
				var serverCore = Context.ActorSelection(serverConnection.GetActorPath("core"));
				onSuccess = connection.SuccessAction;

				serverCore.Tell(new ConnectRequest() {NicknameProposition = connection.NicknameProposition});
			});
		}
	}
}