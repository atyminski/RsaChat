using Xunit;

namespace Gevlee.RsaChat.Common.Cryptography.Tests
{
	public class RsaCryptoServiceTest
	{
		[Fact]
		public void Should_Encode_And_Decode_String()
		{
			var service = new RsaCryptoService();
			var privateKey = new RsaPrivateKey(103, 143);
			var publicKey = new RsaPublicKey(7, 143);

			var toEncode = "Hello World!";
			var encoded = service.Encode(toEncode, publicKey);
			var decoded = service.Decode(encoded, privateKey);

			Assert.Equal(toEncode, decoded);
		}
	}
}