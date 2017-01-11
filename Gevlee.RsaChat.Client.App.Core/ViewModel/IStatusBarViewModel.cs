using Gevlee.RsaChat.Client.App.Core.Model;

namespace Gevlee.RsaChat.Client.App.Core.ViewModel
{
	public interface IStatusBarViewModel
	{
		ServerConnectionStatus ServerConnectionStatus { get; set; }
	}
}