using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Client.App.FakeViewModel
{
	public class FakeChatBoxViewModel : IChatBoxViewModel
	{
		public ICollection<ChatMessage> ChatMessages => new ObservableCollection<ChatMessage>(new []
		{
			new ChatMessage()
			{
				Autor = "Test Autor",
				Content = "This is test content! :)"
			}
		});
	}
}