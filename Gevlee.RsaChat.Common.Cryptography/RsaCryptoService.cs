using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaCryptoService : IRsaCryptoService
	{
		public byte[] Encode(string str, RsaPublicKey key)
		{
			return str.Select(t => BigInteger.ModPow(t, key.E, key.N))
				.SelectMany(a => BitConverter.GetBytes((long)a))
				.ToArray();
		}

		public string Decode(byte[] signs, RsaPrivateKey key)
		{
			return new string(signs.Select((s, i) => new {Value = s, Index = i})
				.GroupBy(arg => arg.Index/8)
				.Select(grouping => BitConverter.ToInt64(grouping.Select(a => a.Value)
					.ToArray(), 0))
				.Select(c => (char)BigInteger.ModPow(c, key.D, key.N))
				.ToArray());
		}
	}
}