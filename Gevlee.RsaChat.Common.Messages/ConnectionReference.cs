using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Common.Messages
{
	public class ConnectionReference
	{
		public string ClientName { get; set; }
		public bool Status { get; set; }
		public ChatMessage Message { get; set; }
	}
}