using Moq;
using Xunit;

namespace Gevlee.RsaChat.Common.Cryptography.Tests
{
	public class RsaKetGeneratorTest
	{
		private IRandomLongProvider randomLongProvider;

		public RsaKetGeneratorTest()
		{
			var mock = new Mock<IRandomLongProvider>();
			mock.SetupSequence(provider => provider.GetNext())
				.Returns(13)
				.Returns(11);

			randomLongProvider = mock.Object;
		}

		[Fact]
		public void Test()
		{
			var obj = new RsaKeyGenerator(randomLongProvider);

			var result = obj.Generate();

			Assert.Equal(7, result.RsaPublicKey.E);
			Assert.Equal(143, result.RsaPublicKey.N);
			Assert.Equal(103, result.RsaPrivateKey.D);
			Assert.Equal(143, result.RsaPrivateKey.N);
		}
	}
}