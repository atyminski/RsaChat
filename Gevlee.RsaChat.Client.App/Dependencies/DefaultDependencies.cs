using System.Configuration;
using Akka.Actor;
using Autofac;
using Gevlee.RsaChat.Client.Actors;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.Services;
using Gevlee.RsaChat.Client.App.ViewModel;
using Gevlee.RsaChat.Client.Model;
using Prism.Events;

namespace Gevlee.RsaChat.Client.App.Dependencies
{
	public class DefaultDependencies : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MainViewModel>().As<IMainViewModel>();
			builder.RegisterType<StatusBarViewModel>().As<IStatusBarViewModel>();
			builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
			builder.RegisterType<EventAggregator>().SingleInstance().As<IEventAggregator>();

			builder.RegisterInstance(ActorSystem.Create("RsaChatClientSystem")).SingleInstance().As<ActorSystem>();
			builder.RegisterInstance(new ServerConnection(ConfigurationManager.AppSettings["ServerUrl"])).SingleInstance();
			builder.RegisterType<ClientCoreActor>();
			builder.RegisterType<ActorService>().SingleInstance().As<IActorService>();
		}
	}
}