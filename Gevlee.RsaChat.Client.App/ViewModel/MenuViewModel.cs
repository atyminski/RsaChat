using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.Model;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Prism.Commands;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class MenuViewModel: ViewModelBase, IMenuViewModel
	{
		private readonly IEventAggregator eventAggregator;

		public MenuViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			ConnectToServerCommand = new DelegateCommand(() =>
			{
				eventAggregator.GetEvent<ServerConnectionStatusChanged>().Publish(new ServerConnectionStatus() {IsConnected = true});
			});
		}

		public DelegateCommand ConnectToServerCommand { get; }
	}
}