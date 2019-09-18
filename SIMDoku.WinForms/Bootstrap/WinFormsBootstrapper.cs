using SIMDoku.DataManagement.Bootstrap;
using SIMDoku.FileManagement.Bootstrap;

namespace SIMDoku.WinForms.Bootstrap
{
	public class WinFormsBootstrapper : DataManagementFileBootstrapper
	{
		public WinFormsBootstrapper() : base(FileType.JSON)
		{

		}

		public override void RegisterServices()
		{
			base.RegisterServices();
		}
	}
}
