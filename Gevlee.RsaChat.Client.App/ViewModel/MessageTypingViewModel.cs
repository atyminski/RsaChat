using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.Model;
using Prism.Commands;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class MessageTypingViewModel : ViewModelBase, IMessageTypingViewModel
	{
		private readonly IApplicationState applicationState;
		private readonly IEventAggregator eventAggregator;
		private string messageText;

		public MessageTypingViewModel(IEventAggregator eventAggregator, IApplicationState applicationState)
		{
			this.eventAggregator = eventAggregator;
			this.applicationState = applicationState;
			ConfigureCommands();
		}

		public string MessageText
		{
			get { return messageText; }
			set
			{
				messageText = value;
				RaisePropertyChanged();
				SendCommand.RaiseCanExecuteChanged();
			}
		}

		public DelegateCommand SendCommand { get; private set; }

		private void ConfigureCommands()
		{
			SendCommand = new DelegateCommand(() =>
			{
				eventAggregator.GetEvent<ChatMessageOutcome>().Publish(new ChatMessage
				{
					Autor = applicationState.UserName,
					Content = MessageText,
					IsEncrypted = true
				});

				MessageText = string.Empty;
			}, () => !string.IsNullOrEmpty(MessageText));
		}
	}
}