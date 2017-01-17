namespace Gevlee.RsaChat.Common.Cryptography
{
	public interface IRsaKeyGenerator
	{
		RsaKeysPair Generate();
	}
}