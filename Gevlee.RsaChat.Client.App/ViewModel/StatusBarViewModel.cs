using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.App.ModelWrappers;
using Gevlee.RsaChat.Client.Model;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
	{
		public StatusBarViewModel(IApplicationState applicationState)
		{
			ApplicationState = applicationState;
		}

		public IApplicationState ApplicationState { get; set; }
	}
}