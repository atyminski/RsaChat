using Autofac;
using Xunit;

namespace Gevlee.RsaChat.Common.Cryptography.Tests
{
	public class RsaIntegrationTest
	{
		private readonly IRsaCryptoService cryptoService;
		private readonly IRsaKeyGenerator keyGenerator;

		public RsaIntegrationTest()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new CryptographyModule());
			var container = builder.Build();
			keyGenerator = container.Resolve<IRsaKeyGenerator>();
			cryptoService = container.Resolve<IRsaCryptoService>();
		}

		[Theory]
		[InlineData("Hello world")]
		[InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor volutpat semper")]
		[InlineData("Środa była chłodna")]
		[InlineData("Źródło rzeki")]
		[InlineData("Mąka do ciasta")]
		public void Should_Encode_And_Decode_Text(string target)
		{
			var keys = keyGenerator.Generate();
			var encoded = cryptoService.Encode(target, keys.RsaPublicKey);
			var decoded = cryptoService.Decode(encoded, keys.RsaPrivateKey);

			Assert.Equal(target, decoded);
		}
	}
}