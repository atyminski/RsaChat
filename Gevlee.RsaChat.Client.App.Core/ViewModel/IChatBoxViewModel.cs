using System.Collections.Generic;
using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Client.App.Core.ViewModel
{
	public interface IChatBoxViewModel
	{
		ICollection<ChatMessage> ChatMessages { get; }
	}
}