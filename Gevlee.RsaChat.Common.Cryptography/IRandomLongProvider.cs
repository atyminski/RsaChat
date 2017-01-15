namespace Gevlee.RsaChat.Common.Cryptography
{
	public interface IRandomLongProvider
	{
		long GetNext();
	}
}