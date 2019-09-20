using Autofac;

using SIMDoku.Core;

namespace SIMDoku.FileManagement.Bootstrap
{
	public class FileHandlerBootstrapper : AutofacBootstrapper
	{
		private readonly FileType _FileType;

		public FileHandlerBootstrapper(ContainerBuilder container, FileType type) : base(container)
		{
			_Container = container;
			_FileType = type;
		}

		public override void RegisterComponents()
		{
			switch (_FileType)
			{
				case FileType.JSON:
					_Container.RegisterType<JsonHandler>().As<IFileHandler>();
					break;
				case FileType.XML:
					_Container.RegisterType<XmlHandler>().As<IFileHandler>();
					break;
				default:
					break;
			}
		}
	}
}