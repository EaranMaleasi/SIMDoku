using Autofac;

using SIMDoku.Core;

namespace SIMDoku.DataManagement.Bootstrap
{
	public class DataManagementFileBootstrapper : AutofacBootstrapper
	{
		public DataManagementFileBootstrapper(ContainerBuilder container) : base(container)
		{
		}

		public override void RegisterComponents()
		{
			_Container.RegisterType<FileDataAccess>().As<IDataProvider>().SingleInstance();
		}
	}
}
