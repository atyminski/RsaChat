using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Client.App.Core.ViewModel
{
	public interface IStatusBarViewModel
	{
		ServerConnectionStatus ServerConnectionStatus { get; set; }
	}
}