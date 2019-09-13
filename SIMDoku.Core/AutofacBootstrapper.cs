using Autofac;

namespace SIMDoku.Core
{
	public abstract class AutofacBootstrapper
	{
		protected ContainerBuilder Container { get; private set; }
		protected AutofacConfiguration Configuration { get; private set; }


		public AutofacBootstrapper(ContainerBuilder container, AutofacConfiguration configuration)
		{
			Container = container;
			Configuration = configuration;
		}

		public abstract void RegisterServices();
	}
}
