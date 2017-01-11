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
			IStatusBarViewModel statusBarViewModel)
		{
			this.eventAggregator = eventAggregator;
			MenuViewModel = menuViewModel;
			StatusBarViewModel = statusBarViewModel;
		}

		public IMenuViewModel MenuViewModel { get; }
		public IStatusBarViewModel StatusBarViewModel { get; }
	}
}