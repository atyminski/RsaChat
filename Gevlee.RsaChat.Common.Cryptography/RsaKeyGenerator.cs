using System.Numerics;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaKeyGenerator : IRsaKeyGenerator
	{
		private readonly IRandomPrimeLongProvider randomPrimeLongProvider;

		public RsaKeyGenerator(IRandomPrimeLongProvider randomPrimeLongProvider)
		{
			this.randomPrimeLongProvider = randomPrimeLongProvider;
		}

		public RsaKeysPair Generate()
		{
			var p = randomPrimeLongProvider.GetNext();
			var q = randomPrimeLongProvider.GetNext();
			while (p == q)
			{
				q = randomPrimeLongProvider.GetNext();
			}

			var phi = (p - 1)*(q - 1);
			var n = p * q;
			long e = 0;
			for (int i = 2; i < n; i++)
			{
				if (BigInteger.GreatestCommonDivisor(i, phi).Equals(BigInteger.One) && i % 2 > 0)
				{
					e = i;
					break;
				}
			}

			var d = ExtendedEuclidean(e, phi);

			return new RsaKeysPair(new RsaPrivateKey(d,n), new RsaPublicKey(e,n));
		}

		private static long ExtendedEuclidean(long a, long b)
		{
			long u, w, x, z, q;
			u = 1; w = a;
			x = 0; z = b;
			while (w != 0)
			{
				if (w < z)
				{
					q = u; u = x; x = q;
					q = w; w = z; z = q;
				}
				q = w / z;
				u -= q * x;
				w -= q * z;
			}
			if (z == 1)
			{
				if (x < 0)
					x += b;
				return x;
			}
			return 0;
		}
	}
}
