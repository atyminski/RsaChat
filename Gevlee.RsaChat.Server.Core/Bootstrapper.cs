using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using Gevlee.RsaChat.Common.Cryptography;
using Gevlee.RsaChat.Server.Core.Actors;
using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Targets;

namespace Gevlee.RsaChat.Server.Core
{
	public class Bootstrapper
	{
		public void Run()
		{
			var builder = new ContainerBuilder();
			ConfigureLogger();
			ConfigureModules(builder);

			var scope = builder.Build().BeginLifetimeScope();
			var system = scope.Resolve<ActorSystem>();
			new AutoFacDependencyResolver(scope, system);
			system.ActorOf(system.DI().Props<ServerCoreActor>(), "core");
		}

		private void ConfigureLogger()
		{
			var config = new LoggingConfiguration();
			config.AddTarget(new FileTarget
			{
				FileName = "server.log",
				Name = "file"
			});
			config.AddTarget(new ColoredConsoleTarget
			{
				Name = "console",
				RowHighlightingRules =
				{
					new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Info"), ConsoleOutputColor.Green,
						ConsoleOutputColor.NoChange)
				}
			});

			config.AddRule(LogLevel.Info, LogLevel.Warn, "console", "*Akka*");
			config.AddRule(LogLevel.Warn, LogLevel.Fatal, "file", "Gevlee.RsaChat*");
			config.AddRule(LogLevel.Info, LogLevel.Fatal, "console", "Gevlee.RsaChat*");

			LogManager.Configuration = config;
		}

		private void ConfigureModules(ContainerBuilder builder)
		{
			builder.RegisterModule<CryptographyModule>();
			builder.RegisterModule<DefaultModule>();
		}
	}
}