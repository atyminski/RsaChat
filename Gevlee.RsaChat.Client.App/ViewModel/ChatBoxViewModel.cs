using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Events;
using Gevlee.RsaChat.Client.Model;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class ChatBoxViewModel : ViewModelBase, IChatBoxViewModel
	{
		public ChatBoxViewModel(IEventAggregator eventAggregator)
		{
			ChatMessages = new ObservableCollection<ChatMessage>();
			eventAggregator.GetEvent<ChatMessageIncoming>().Subscribe(AddChatMessage);
		}

		public ICollection<ChatMessage> ChatMessages { get; }

		private void AddChatMessage(ChatMessage obj)
		{
			Application.Current.Dispatcher.Invoke(() => { ChatMessages.Add(obj); });
		}
	}
}