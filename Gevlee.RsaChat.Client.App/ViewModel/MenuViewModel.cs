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
		private readonly IApplicationState applicationState;
		private readonly IKeysStorage keysStorage;

		public MenuViewModel(
			IEventAggregator eventAggregator, 
			IActorService actorService, 
			IApplicationState applicationState, 
			IKeysStorage keysStorage)
		{
			this.eventAggregator = eventAggregator;
			this.actorService = actorService;
			this.applicationState = applicationState;
			this.keysStorage = keysStorage;
			ConnectToServerCommand = new DelegateCommand(() =>
			{
				var core = actorService.CreateActor<ClientCoreActor>("core");
				core.Tell(new ServerConnection()
				{
					NicknameProposition = "TestClient",
					SuccessAction = (reference) =>
					{
						applicationState.IsConnectedToServer = reference.Status;
						applicationState.UserName = reference.ClientName;

						if (reference.Message != null)
						{
							eventAggregator.GetEvent<ChatMessageIncoming>().Publish(reference.Message);
						}
					}
				});
			});
		}

		public DelegateCommand ConnectToServerCommand { get; }
	}
}