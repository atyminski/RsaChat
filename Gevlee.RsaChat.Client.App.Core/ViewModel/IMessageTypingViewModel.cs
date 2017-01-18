using Prism.Commands;

namespace Gevlee.RsaChat.Client.App.Core.ViewModel
{
	public interface IMessageTypingViewModel
	{
		string MessageText { get; set; }
		DelegateCommand SendCommand { get; }
	}
}