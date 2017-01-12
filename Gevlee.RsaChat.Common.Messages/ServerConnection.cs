using System;

namespace Gevlee.RsaChat.Common.Messages
{
	public class ServerConnection
	{
		public Action<ConnectionReference> SuccessAction { get; set; }
		public string NicknameProposition { get; set; }
	}
}