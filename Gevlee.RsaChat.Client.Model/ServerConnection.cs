namespace Gevlee.RsaChat.Client.Model
{
	public class ServerConnection
	{
		public ServerConnection(string address)
		{
			Address = address;
		}

		public string Address { get; set; }

		public string GetActorPath(string name)
		{
			return $"{Address}/user/{name}";
		}
	}
}