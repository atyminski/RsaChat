namespace Gevlee.RsaChat.Client.Model
{
	public class ChatMessage
	{
		public string Autor { get; set; }
		public bool IsEncrypted { get; set; }
		public string Content { get; set; }
	}
}