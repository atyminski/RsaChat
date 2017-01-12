using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.Model;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
	{
		private ServerConnectionStatus serverConnectionStatus;

		public StatusBarViewModel(IEventAggregator eventAggregator)
		{
			ServerConnectionStatus = new ServerConnectionStatus();
			SubscribeEvents(eventAggregator);
		}

		private void SubscribeEvents(IEventAggregator eventAggregator)
		{
			eventAggregator.GetEvent<ServerConnectionStatusChanged>().Subscribe(status =>
			{
				ServerConnectionStatus = status;
			});
		}

		public ServerConnectionStatus ServerConnectionStatus
		{
			get { return serverConnectionStatus; }
			set
			{
				serverConnectionStatus = value;
				RaisePropertyChanged();
			}
		}
	}
}