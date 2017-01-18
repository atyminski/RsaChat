using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RsaCryptoService : IRsaCryptoService
	{
		public byte[] Encode(string str, RsaPublicKey key)
		{
			return str.Select(t => BigInteger.ModPow(t, key.E, key.N))
				.SelectMany(a => BitConverter.GetBytes((long) a))
				.ToArray();
		}

		public string Decode(byte[] signs, RsaPrivateKey key)
		{
			return new string(GetLongArrayFromBytesArray(signs)
				.Select(c => (char) BigInteger.ModPow(c, key.D, key.N))
				.ToArray());
		}

		public void TryGetEncodedSigns(byte[] endodedContent, out string outStr)
		{
			try
			{
				outStr = "BASE64: " + Convert.ToBase64String(GetBytesFromString(new string(GetLongArrayFromBytesArray(endodedContent).Select(a => (char)a).ToArray())));
			}
			catch (Exception)
			{
				outStr = "ONLY NUMBERS: " + string.Join("", GetLongArrayFromBytesArray(endodedContent).Select(a => a.ToString()).ToArray());
			}
		}

		private long[] GetLongArrayFromBytesArray(byte[] bytes)
		{
			return bytes.Select((s, i) => new {Value = s, Index = i})
				.GroupBy(arg => arg.Index/8)
				.Select(grouping => BitConverter.ToInt64(grouping.Select(a => a.Value)
					.ToArray(), 0)).ToArray();
		}

		private byte[] GetBytesFromString(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
	}
}