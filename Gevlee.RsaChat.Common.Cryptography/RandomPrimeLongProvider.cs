using System;
using System.Collections.Generic;
using System.Linq;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class RandomPrimeLongProvider : IRandomPrimeLongProvider
	{
		private readonly ICollection<long> primes;

		public RandomPrimeLongProvider(long maxVal, long minVal)
		{
			MaxVal = maxVal;
			MinVal = minVal;
			primes = new HashSet<long>();
			GeneratePrimes();
		}

		public long MaxVal { get; }
		public long MinVal { get; }

		public long GetNext()
		{
			var rand = new Random(DateTime.Now.Millisecond);
			var index = rand.Next(0, primes.Count);
			var result = primes.ElementAt(index);
			if (result < MinVal)
				return GetNext();
			return result;
		}

		private void GeneratePrimes()
		{
			primes.Add(2);

			for (long checkValue = 3; checkValue <= MaxVal; checkValue += 2)
				if (IsPrime(checkValue))
					primes.Add(checkValue);
		}

		private bool IsPrime(long checkValue)
		{
			var isPrime = true;

			foreach (var prime in primes)
				if ((checkValue%prime == 0) && (prime <= Math.Sqrt(checkValue)))
				{
					isPrime = false;
					break;
				}

			return isPrime;
		}
	}
}