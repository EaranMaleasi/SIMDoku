using SIMDoku.Models;

using System;
using System.Windows.Forms;

namespace SIMDoku.WinForms.Dialogs
{
	public partial class DocumentsDialog : Form, IDialog
	{
		private Document CurrentDocument;

		public DocumentsDialog()
		{
			InitializeComponent();
		}

		public void CloseDialog()
		{
			this.Hide();
		}

		public void NewRow<T>()
		{
			Clean();
			this.ShowDialog();
		}

		public void UpdateRow<T>(T row)
		{
			if (row is Document doc)
			{
				CurrentDocument = doc;
				this.ShowDialog();
			}
			else
			{
				throw new ArgumentException("Only Document is supported!", nameof(row));
			}
		}

		public void Clean()
		{
			//TODO: Implement Cleanup
		}

	}
}
