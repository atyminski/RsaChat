using Akka.Actor;
using Autofac;
using Gevlee.RsaChat.Server.Core.Actors;
using Gevlee.RsaChat.Server.Core.Services;

namespace Gevlee.RsaChat.Server.Core
{
	public class DefaultModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(ActorSystem.Create("RsaChatSystem")).SingleInstance();
			builder.RegisterType<AutoClientNameProvider>().As<IClientNameProvider>().SingleInstance();
			builder.RegisterType<ServerCoreActor>();
			builder.RegisterType<ClientHandler>();
		}
	}
}