using System;
using Autofac;

namespace Gevlee.RsaChat.Common.Cryptography
{
	public class CryptographyModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<RandomPrimeLongProvider>().As<IRandomPrimeLongProvider>().WithParameter("maxVal", 50).WithParameter("minVal", 1);
			builder.RegisterType<RsaCryptoService>().As<IRsaCryptoService>();
			builder.RegisterType<RsaKeyGenerator>().As<IRsaKeyGenerator>();
		}
	}
}