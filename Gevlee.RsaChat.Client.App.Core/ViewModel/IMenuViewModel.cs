using Prism.Commands;

namespace Gevlee.RsaChat.Client.App.Core.ViewModel
{
	public interface IMenuViewModel
	{
		DelegateCommand ConnectToServerCommand { get; }
	}
}