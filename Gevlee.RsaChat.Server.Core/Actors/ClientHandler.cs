using Akka.Actor;
using Akka.Event;
using Gevlee.RsaChat.Common.Cryptography;
using Gevlee.RsaChat.Common.Messages;
using Gevlee.RsaChat.Server.Core.Messages;

namespace Gevlee.RsaChat.Server.Core.Actors
{
	public class ClientHandler : ReceiveActor
	{
		private readonly IRsaCryptoService rsaCryptoService;
		private HandleReference handleReference;

		public ClientHandler(IRsaCryptoService rsaCryptoService)
		{
			this.rsaCryptoService = rsaCryptoService;

			Receive<HandleReference>(reference =>
			{
				handleReference = reference;
				Context.GetLogger().Info($"Handle reference for : {handleReference.ClientName}");
				handleReference.ClientRef.Tell(new EncodedChatMessage
				{
					MessageBytes = rsaCryptoService.Encode("Witaj! Zostałeś podłączony do serwera", handleReference.ClientPublicKey),
					Author = "Server"
				});
				Context.GetLogger().Info($"Welcome message sent to : {handleReference.ClientName}");
			});

			Receive<EncodedChatMessage>(message =>
			{
				Context.GetLogger().Info($"New message from {handleReference.ClientName}");
				TryLogEncodedMessage(message);
				var shoutcastMessage = new ShoutcastMessage
				{
					Author = message.Author,
					Content = this.rsaCryptoService.Decode(message.MessageBytes, handleReference.ServeRsaPrivateKey)
				};
				Context.ActorSelection("../handlerof*").Tell(shoutcastMessage);
				Context.GetLogger().Info($"Message from {handleReference.ClientName} was shoutcasted to other clients");
			});

			Receive<ShoutcastMessage>(message =>
			{
				handleReference.ClientRef.Tell(new EncodedChatMessage
				{
					Author = message.Author,
					MessageBytes = rsaCryptoService.Encode(message.Content, handleReference.ClientPublicKey)
				});
			});
		}

		private void TryLogEncodedMessage(EncodedChatMessage msg)
		{
			string message;
			rsaCryptoService.TryGetEncodedSigns(msg.MessageBytes, out message);
			if (!string.IsNullOrEmpty(message))
				Context.GetLogger().Info($"\nAuthor:{msg.Author}\nEncoded msg:\n{message}");
		}
	}
}