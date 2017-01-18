using Akka.Actor;
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
				handleReference.ClientRef.Tell(new EncodedChatMessage()
				{
					MessageBytes = rsaCryptoService.Encode("Witaj! Zostałeś podłączony do serwera", handleReference.ClientPublicKey),
					Author = "Server"
				});
			});

			Receive<EncodedChatMessage>((message =>
			{
				Context.ActorSelection("../handlerof*").Tell(new ShoutcastMessage()
				{
					Author = message.Author,
					Content = this.rsaCryptoService.Decode(message.MessageBytes, handleReference.ServeRsaPrivateKey)
				});
			}));

			Receive<ShoutcastMessage>((message =>
			{
				handleReference.ClientRef.Tell(new EncodedChatMessage()
				{
					Author = message.Author,
					MessageBytes = rsaCryptoService.Encode(message.Content, handleReference.ClientPublicKey)
				});

			}));
		}
	}
}