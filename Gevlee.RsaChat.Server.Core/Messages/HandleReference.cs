using Akka.Actor;
using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Server.Core.Messages
{
	public class HandleReference
	{
		public string ClientName { get; set; }
		public IActorRef ClientRef { get; set; }
		public RsaPrivateKey ServeRsaPrivateKey { get; set; }
		public RsaPublicKey ClientPublicKey { get; set; }
	}
}