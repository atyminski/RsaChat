using System;
using Akka.Actor;
using Akka.DI.Core;
using Akka.Event;
using Gevlee.RsaChat.Client.Model;
using Gevlee.RsaChat.Common.Cryptography;
using Gevlee.RsaChat.Common.Messages;
using Gevlee.RsaChat.Server.Core.Messages;
using Gevlee.RsaChat.Server.Core.Services;
using NLog;

namespace Gevlee.RsaChat.Server.Core.Actors
{
	public class ServerCoreActor : ReceiveActor
	{
		private readonly IClientNameProvider clientNameProvider;
		private RsaKeysPair keys;

		public ServerCoreActor(IRsaKeyGenerator rsaKeyGenerator, IClientNameProvider clientNameProvider)
		{
			this.clientNameProvider = clientNameProvider;
			keys = rsaKeyGenerator.Generate();

			Receive<ConnectRequest>(request =>
			{
				var clientName = clientNameProvider.Get(request.NicknameProposition);
				Context.GetLogger().Info($"New connection: {clientName}");

				var handler = Context.ActorOf(Context.DI().Props<ClientHandler>(), $"handlerof{clientName}");

				Sender.Tell(new ConnectionReference()
				{
					Status = true,
					HandlerRef = handler,
					ClientName = clientName,
					ServerPublicKey = keys.RsaPublicKey
				});

				handler.Tell(new HandleReference()
				{
					ClientName = clientName,
					ServeRsaPrivateKey = keys.RsaPrivateKey,
					ClientRef = Sender,
					ClientPublicKey = request.PublicKey
				});
			});
		}

		protected override void PreStart()
		{
		}
	}
}