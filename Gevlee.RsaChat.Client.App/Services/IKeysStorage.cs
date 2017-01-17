using Gevlee.RsaChat.Common.Cryptography;

namespace Gevlee.RsaChat.Client.App.Services
{
	public interface IKeysStorage
	{
		RsaPrivateKey ClientPrivateKey { get; }

		RsaPublicKey ClientPublicKey { get; }

		RsaPublicKey ServerKey { get; set; }
	}
}