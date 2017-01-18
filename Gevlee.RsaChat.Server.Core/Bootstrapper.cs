using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using Gevlee.RsaChat.Common.Cryptography;
using Gevlee.RsaChat.Server.Core.Actors;

namespace Gevlee.RsaChat.Server.Core
{
	public class Bootstrapper
	{
		public void Run()
		{
			var builder = new ContainerBuilder();

			ConfigureModules(builder);

			var scope = builder.Build().BeginLifetimeScope();
			var system = scope.Resolve<ActorSystem>();
			new AutoFacDependencyResolver(scope, system);
			system.ActorOf(system.DI().Props<ServerCoreActor>(), "core");
		}

		private void ConfigureModules(ContainerBuilder builder)
		{
			builder.RegisterModule<CryptographyModule>();
			builder.RegisterModule<DefaultModule>();
		}
	}
}