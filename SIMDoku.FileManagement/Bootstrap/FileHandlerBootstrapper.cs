using Autofac;

using SIMDoku.Core;

namespace SIMDoku.FileManagement.Bootstrap
{
	public class FileHandlerBootstrapper : AutofacBootstrapper
	{
		private readonly FileType fileType;

		public FileHandlerBootstrapper(FileType type) : base()
		{
			fileType = type;
		}

		public override void RegisterServices()
		{
			switch (fileType)
			{
				case FileType.JSON:
					Container.RegisterType<JsonHandler>().As<IFileHandler>();
					break;
				case FileType.XML:
					Container.RegisterType<XmlHandler>().As<IFileHandler>();
					break;
				default:
					break;
			}
		}
	}
}