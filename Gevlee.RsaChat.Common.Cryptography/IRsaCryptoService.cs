namespace Gevlee.RsaChat.Common.Cryptography
{
	public interface IRsaCryptoService
	{
		byte[] Encode(string str, RsaPublicKey key);
		string Decode(byte[] signs, RsaPrivateKey key);
		void TryGetEncodedSigns(byte[] endodedContent, out string outStr);
	}
}