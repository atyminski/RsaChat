using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
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
			IChatBoxViewModel chatBoxViewModel)
		{
			this.eventAggregator = eventAggregator;
			ChatBoxViewModel = chatBoxViewModel;
			MenuViewModel = menuViewModel;
			StatusBarViewModel = statusBarViewModel;
		}

		public IMenuViewModel MenuViewModel { get; }
		public IStatusBarViewModel StatusBarViewModel { get; }
		public IChatBoxViewModel ChatBoxViewModel { get; }
	}
}