namespace Gevlee.RsaChat.Client.Model
{
	public interface IApplicationState
	{
		bool IsConnectedToServer { get; set; }
		string UserName { get; set; }
	}
}