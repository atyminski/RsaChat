using Akka.Actor;
using Gevlee.RsaChat.Client.Model;
using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Common.Messages
{
	public class ConnectionReference
	{
		public string ClientName { get; set; }
		public bool Status { get; set; }
		public ChatMessage Message { get; set; }
		public IActorRef HandlerRef { get; set; }
		public RsaPublicKey ServerPublicKey { get; set; }
	}
}