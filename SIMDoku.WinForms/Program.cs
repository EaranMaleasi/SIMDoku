using Autofac;

using SIMDoku.WinForms.Bootstrap;

using System;
using System.Windows.Forms;

namespace SIMDoku.WinForms
{
	static class Program
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			WinFormsBootstrapper wfb = new WinFormsBootstrapper();
			IContainer container = wfb.RegisterComponents();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());



		}
	}
}
