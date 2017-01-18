namespace Gevlee.RsaChat.Server.Core.Services
{
	public class AutoClientNameProvider : IClientNameProvider
	{
		private int counter;

		public string Get()
		{
			counter++;
			return $"Client_{counter}";
		}

		public string Get(string proposition)
		{
			return Get();
		}
	}
}