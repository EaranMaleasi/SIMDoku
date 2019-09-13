using Autofac;

using SIMDoku.Core;
using SIMDoku.DataAccess.Implementation;

namespace SIMDoku.DataAccess.Bootstrap
{
	public class DataAccessBootstrapper : AutofacBootstrapper
	{
		public DataAccessBootstrapper(ContainerBuilder container, AutofacConfiguration configuration) : base(container, configuration)
		{ }

		public override void RegisterServices()
		{
			if (Configuration.DataAccess.HasFlag(DataAccessConfiguration.SimpleDataAccess))
			{
				Container.RegisterType<SimDatabase>().As<ISimDatabase>().SingleInstance();
			}

		}
	}
}
