using Autofac;

using SIMDoku.Core;

namespace SIMDoku.Messaging.Bootstrap
{
	public class MessagingBootstrapper : AutofacBootstrapper
	{
		public MessagingBootstrapper(ContainerBuilder container) : base(container)
		{
		}

		public override void RegisterComponents()
		{
			_Container.RegisterType<MessagingCenter>().As<IMessagingCenter>();
		}
	}
}
