using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.Model;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class MainViewModel : ViewModelBase, IMainViewModel
	{
		private readonly IEventAggregator eventAggregator;

		public MainViewModel(
			IEventAggregator eventAggregator,
			IMenuViewModel menuViewModel,
			IStatusBarViewModel statusBarViewModel,
			IChatBoxViewModel chatBoxViewModel,
			IMessageTypingViewModel messageTypingViewModel,
			IApplicationState applicationState)
		{
			this.eventAggregator = eventAggregator;
			ChatBoxViewModel = chatBoxViewModel;
			MenuViewModel = menuViewModel;
			StatusBarViewModel = statusBarViewModel;
			MessageTypingViewModel = messageTypingViewModel;
			ApplicationState = applicationState;
		}

		public IMenuViewModel MenuViewModel { get; }
		public IStatusBarViewModel StatusBarViewModel { get; }
		public IChatBoxViewModel ChatBoxViewModel { get; }
		public IMessageTypingViewModel MessageTypingViewModel { get; }
		public IApplicationState ApplicationState { get; }
	}
}