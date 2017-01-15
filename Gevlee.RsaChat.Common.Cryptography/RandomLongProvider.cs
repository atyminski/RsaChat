using System;
using System.Security.Cryptography;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RandomLongProvider : IRandomLongProvider
	{
		public long GetNext()
		{
			var rng = RandomNumberGenerator.Create();
			var bytes = new byte[8];
			rng.GetNonZeroBytes(bytes);
			return BitConverter.ToInt64(bytes, 0);
		}
	}
}