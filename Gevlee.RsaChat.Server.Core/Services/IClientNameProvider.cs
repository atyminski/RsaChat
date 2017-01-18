namespace Gevlee.RsaChat.Server.Core.Services
{
	public interface IClientNameProvider
	{
		string Get();
		string Get(string proposition);
	}
}