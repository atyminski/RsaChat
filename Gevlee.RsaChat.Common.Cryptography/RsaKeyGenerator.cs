using System.Numerics;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaKeyGenerator
	{
		private readonly IRandomLongProvider randomLongProvider;

		public RsaKeyGenerator(IRandomLongProvider randomLongProvider)
		{
			this.randomLongProvider = randomLongProvider;
		}
		public RsaKeysPair Generate()
		{
			var p = randomLongProvider.GetNext();
			var q = randomLongProvider.GetNext();

			var phi = (p - 1)*(q - 1);
			var n = p * q;
			long e = 0;
			for (int i = 2; i < n; i++)
			{
				if (BigInteger.GreatestCommonDivisor(i, phi).Equals(BigInteger.One))
				{
					e = i;
					break;
				}
			}

			var d = (long)BigInteger.ModPow(e, e, phi);

			return new RsaKeysPair(new RsaPrivateKey(d,n), new RsaPublicKey(e,n));
		}
	}
}
