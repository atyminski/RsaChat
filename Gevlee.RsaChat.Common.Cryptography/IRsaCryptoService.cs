using System.Collections.Generic;
using System.Numerics;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public interface IRsaCryptoService
	{
		IEnumerable<BigInteger> Encode(IEnumerable<char> signs, RsaPublicKey key);
		IEnumerable<char> Decode(IEnumerable<BigInteger> signs, RsaPrivateKey key);
	}
}