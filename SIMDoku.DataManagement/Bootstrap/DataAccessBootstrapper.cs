using Autofac;

using SIMDoku.FileManagement;
using SIMDoku.FileManagement.Bootstrap;

namespace SIMDoku.DataManagement.Bootstrap
{
	public class DataManagementFileBootstrapper : FileHandlerBootstrapper
	{
		public DataManagementFileBootstrapper(FileType type) : base(type)
		{

		}

		public override void RegisterServices()
		{
			Container.RegisterType<FileDataAccess>().As<IDataProvider>().SingleInstance();
		}
	}
}
