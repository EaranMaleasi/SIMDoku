namespace SIMDoku.Core
{
	public class AutofacConfiguration
	{
		public PlattformConfiguration Plattform { get; set; }
		public DisplayConfiguration Display { get; set; }
		public DataAccessConfiguration DataAccess { get; set; }
		public DataAccessConfiguration DataObjects { get; set; }
	}

	public enum PlattformConfiguration
	{
		/// <summary>
		/// The main Plattform is Windows.
		/// </summary>
		Windows,
		/// <summary>
		/// The Plattform is everyhting that Xamarin allows us to get on. This includes Windows (WPF and UWP), iOS and macOS, Android, Linux(GTK)
		/// </summary>
		Xamarin,
		/// <summary>
		/// The app will be hosted as a ASP.NET Core application
		/// </summary>
		AspNetCore
	}

	public enum DisplayConfiguration
	{
		/// <summary>
		/// The app will be displayed using Windows Forms
		/// </summary>
		WinForms,
		/// <summary>
		/// The app will be displayed using WPF
		/// </summary>
		WPF,
		/// <summary>
		/// The app will be displayed using Xamarin.Forms
		/// </summary>
		XamarinForms,
		/// <summary>
		/// The app will be displayed as a ASP.NET Core webpage
		/// </summary>
		AspNetCorePage,
	}

	public enum DataAccessConfiguration
	{

		SimpleDataAccess,
		ObjectRelationalMapper,
		EntityFramework,
		WebAPI
	}

	public enum DataObjectConfiguration
	{
		SimpleDataObjects,
		MvvmModels,
		EFReposiotory
	}
}
