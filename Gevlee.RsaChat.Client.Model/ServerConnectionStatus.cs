using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Client.Model
{
	public class ServerConnectionStatus
	{
		public bool IsConnected { get; set; }
		public ClientUser As { get; set; }
		public RsaPublicKey ServerPublicKey { get; set; }
	}
}