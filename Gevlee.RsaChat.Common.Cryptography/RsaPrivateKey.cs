namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaPrivateKey
	{
		public RsaPrivateKey(long d, long n)
		{
			D = d;
			N = n;
		}

		public long D { get; }
		public long N { get; }
	}
}