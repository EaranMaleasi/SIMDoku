using Autofac;

namespace SIMDoku.Core
{
	public abstract class AutofacBootstrapper
	{
		protected ContainerBuilder _Container;

		public AutofacBootstrapper(ContainerBuilder container)
		{
			_Container = container;
		}

		public abstract void RegisterComponents();
	}
}
