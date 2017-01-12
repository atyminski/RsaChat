using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
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
		public ICollection<ChatMessage> ChatMessages { get; }

		public ChatBoxViewModel(IEventAggregator eventAggregator)
		{
			ChatMessages = new ObservableCollection<ChatMessage>();
			eventAggregator.GetEvent<ChatMessageIncoming>().Subscribe(AddChatMessage);
		}

		private void AddChatMessage(ChatMessage obj)
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				ChatMessages.Add(obj);
			});
		}
	}
}