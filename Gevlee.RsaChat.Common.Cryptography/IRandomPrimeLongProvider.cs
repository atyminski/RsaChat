namespace Gevlee.RsaChat.Common.Cryptography
{
	public interface IRandomPrimeLongProvider
	{
		long GetNext();
	}
}