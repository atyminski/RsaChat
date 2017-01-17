using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaCryptoService : IRsaCryptoService
	{
		public IEnumerable<BigInteger> Encode(IEnumerable<char> signs, RsaPublicKey key)
		{
			return signs.Select(a => (int) a).Select(t => BigInteger.ModPow(t, key.E, key.N));
		}

		public IEnumerable<char> Decode(IEnumerable<BigInteger> signs, RsaPrivateKey key)
		{
			return signs.Select(c => BigInteger.ModPow(c, key.D, key.N)).Select(t => (char)(int)t);
		}
	}
}