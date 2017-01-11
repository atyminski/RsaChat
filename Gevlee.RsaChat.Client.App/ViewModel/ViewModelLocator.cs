using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Dependencies;
using Microsoft.Practices.ServiceLocation;

namespace Gevlee.RsaChat.Client.App.ViewModel
{
	public class ViewModelLocator
	{
		public ViewModelLocator()
		{
			var builder = new ContainerBuilder();

			//if (ViewModelBase.IsInDesignModeStatic)
			//{
			//}
			//else
			//{
				
			//}

			builder.RegisterModule<DefaultDependencies>();
			var container = builder.Build();

			ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
		}

		public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();
	}
}