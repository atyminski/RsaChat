using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Client.App.Services
{
	public class KeysStorage : IKeysStorage
	{
		public KeysStorage(IRsaKeyGenerator keyGenerator)
		{
			var pair = keyGenerator.Generate();
			ClientPrivateKey = pair.RsaPrivateKey;
			ClientPublicKey = pair.RsaPublicKey;
		}
		public RsaPrivateKey ClientPrivateKey { get; }

		public RsaPublicKey ClientPublicKey { get; }

		public RsaPublicKey ServerKey { get; set; }
	}
}