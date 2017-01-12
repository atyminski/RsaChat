using Akka.Actor;
using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.Actors;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.App.Services;
using Gevlee.RsaChat.Client.Model;
using Gevlee.RsaChat.Common.Actors;
using Gevlee.RsaChat.Common.Messages;
using Prism.Commands;
using Prism.Events;
using ServerConnection = Gevlee.RsaChat.Common.Messages.ServerConnection;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class MenuViewModel: ViewModelBase, IMenuViewModel
	{
		private readonly IEventAggregator eventAggregator;
		private readonly IActorService actorService;

		public MenuViewModel(IEventAggregator eventAggregator, IActorService actorService)
		{
			this.eventAggregator = eventAggregator;
			this.actorService = actorService;
			ConnectToServerCommand = new DelegateCommand(() =>
			{
				var core = actorService.CreateActor<ClientCoreActor>("core");
				core.Tell(new ServerConnection()
				{
					NicknameProposition = "TestClient",
					SuccessAction = (reference) =>
					{
						eventAggregator.GetEvent<ServerConnectionStatusChanged>().Publish(new ServerConnectionStatus()
						{
							IsConnected = reference.Status,
							As = new ClientUser()
							{
								Nickname = reference.ClientName
							}
						});
					}
				});
			});
		}

		public DelegateCommand ConnectToServerCommand { get; }
	}
}