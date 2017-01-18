using System.Windows;
using Akka.Actor;
using Akka.DI.AutoFac;
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

			var autoFacDependencyResolver = new AutoFacDependencyResolver(container, container.Resolve<ActorSystem>());
			ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
			Application.Current.Exit += (sender, args) => { container.Resolve<ActorSystem>().Terminate(); };
		}

		public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();
	}
}