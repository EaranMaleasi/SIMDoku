using Autofac;

using SIMDoku.DataManagement.Bootstrap;
using SIMDoku.FileManagement.Bootstrap;
using SIMDoku.Messaging.Bootstrap;

namespace SIMDoku.WinForms.Bootstrap
{
	public class WinFormsBootstrapper
	{
		private DataManagementFileBootstrapper _DataManagement;
		private FileHandlerBootstrapper _FileHandler;
		private MessagingBootstrapper _Messaging;
		private ContainerBuilder _Container;

		public WinFormsBootstrapper()
		{
			_Container = new ContainerBuilder();
			_FileHandler = new FileHandlerBootstrapper(_Container, FileType.JSON);
			_DataManagement = new DataManagementFileBootstrapper(_Container);
			_Messaging = new MessagingBootstrapper(_Container);
		}

		public IContainer RegisterComponents()
		{
			_FileHandler.RegisterComponents();
			_DataManagement.RegisterComponents();
			_Messaging.RegisterComponents();

			return _Container.Build();
		}
	}
}
