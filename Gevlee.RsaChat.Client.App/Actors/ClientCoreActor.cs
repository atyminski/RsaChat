using System;
using System.Windows;
using Akka.Actor;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.Model;
using Gevlee.RsaChat.Common.Cryptography;
using Gevlee.RsaChat.Common.Messages;
using Prism.Events;
using ServerConnection = Gevlee.RsaChat.Common.Messages.ServerConnection;

namespace Gevlee.RsaChat.Client.App.Actors
{
	public class ClientCoreActor : ReceiveActor
	{
		private readonly Model.ServerConnection serverConnection;
		private readonly IKeysStorage keysStorage;
		private readonly IApplicationState applicationState;
		private readonly IEventAggregator eventAggregator;
		private readonly IRsaCryptoService rsaCryptoService;
		private IActorRef serverHandler;

		public ClientCoreActor(
			Model.ServerConnection serverConnection, 
			IKeysStorage keysStorage, 
			IApplicationState applicationState,
			IEventAggregator eventAggregator,
			IRsaCryptoService rsaCryptoService)
		{
			this.serverConnection = serverConnection;
			this.keysStorage = keysStorage;
			this.applicationState = applicationState;
			this.eventAggregator = eventAggregator;
			this.rsaCryptoService = rsaCryptoService;

			Receive<ConnectionReference>(reference =>
			{
				keysStorage.ServerKey = reference.ServerPublicKey;
				applicationState.IsConnectedToServer = reference.Status;
				applicationState.UserName = reference.ClientName;
				serverHandler = reference.HandlerRef;
			});

			Receive<ServerConnection>(connection =>
			{
				var serverCore = Context.ActorSelection(serverConnection.GetActorPath("core"));

				serverCore.Tell(new ConnectRequest()
				{
					NicknameProposition = connection.NicknameProposition,
					PublicKey = keysStorage.ClientPublicKey
				});
			});

			Receive<EncodedChatMessage>(message =>
			{
				eventAggregator.GetEvent<ChatMessageIncoming>().Publish(new ChatMessage()
				{
					Content = rsaCryptoService.Decode(message.MessageBytes, keysStorage.ClientPrivateKey),
					Autor = message.Author,
					IsEncrypted = true
				});
			});

			SubscribeEvents();
		}

		private void SubscribeEvents()
		{
			eventAggregator.GetEvent<ChatMessageOutcome>().Subscribe(message =>
			{
				var encodedMessage = new EncodedChatMessage()
				{
					Author = message.Autor,
					MessageBytes = rsaCryptoService.Encode(message.Content, keysStorage.ServerKey)
				};
				//TODO: add encrypted content
				serverHandler.Tell(encodedMessage);
			});
		}
	}
}