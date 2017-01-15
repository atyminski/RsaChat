namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaKeysPair
	{
		public RsaKeysPair(RsaPrivateKey rsaPrivateKey, RsaPublicKey rsaPublicKey)
		{
			RsaPrivateKey = rsaPrivateKey;
			RsaPublicKey = rsaPublicKey;
		}

		public RsaPrivateKey RsaPrivateKey { get; }
		public RsaPublicKey RsaPublicKey { get; }
	}
}