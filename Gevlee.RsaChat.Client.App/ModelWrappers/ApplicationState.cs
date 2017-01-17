using GalaSoft.MvvmLight;
using Gevlee.RsaChat.Client.Model;

namespace Gevlee.RsaChat.Client.App.ModelWrappers
{
	public class ApplicationState : ObservableObject, IApplicationState
	{
		private string userName;
		private bool isConnectedToServer;

		public bool IsConnectedToServer
		{
			get { return isConnectedToServer; }
			set
			{
				isConnectedToServer = value; 
				RaisePropertyChanged();
			}
		}

		public string UserName
		{
			get { return userName; }
			set
			{
				userName = value; 
				RaisePropertyChanged();
			}
		}
	}
}