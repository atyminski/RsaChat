using Autofac;
using Gevlee.RsaChat.Client.App.Core.ViewModel;
using Gevlee.RsaChat.Client.App.ViewModel;
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
		}
	}
}