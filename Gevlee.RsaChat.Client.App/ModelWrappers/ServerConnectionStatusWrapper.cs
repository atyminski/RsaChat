using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Client.App.ModelWrappers
{
	public class ServerConnectionStatusWrapper : BaseModelWrapper<ServerConnectionStatus>
	{
		public ServerConnectionStatusWrapper(ServerConnectionStatus model) : base(model)
		{
		}

		public override void Replace(ServerConnectionStatus model)
		{
			throw new System.NotImplementedException();
		}
	}
}