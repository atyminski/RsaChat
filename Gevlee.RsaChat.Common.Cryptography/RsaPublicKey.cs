namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaPublicKey
	{
		public RsaPublicKey(long e, long n)
		{
			E = e;
			N = n;
		}

		public long E { get; set; }
		public long N { get; set; }
	}
}