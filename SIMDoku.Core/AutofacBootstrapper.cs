using Autofac;

namespace SIMDoku.Core
{
	public abstract class AutofacBootstrapper
	{
		protected ContainerBuilder Container { get; }


		public AutofacBootstrapper()
		{
			Container = new ContainerBuilder();
		}

		public abstract void RegisterServices();

		public IContainer BuildContainer()
		{
			return Container.Build();
		}
	}
}
