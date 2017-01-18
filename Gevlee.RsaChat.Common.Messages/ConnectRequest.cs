using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Common.Messages
{
	public class ConnectRequest
	{
		public string NicknameProposition { get; set; }
		public RsaPublicKey PublicKey { get; set; }
	}
}