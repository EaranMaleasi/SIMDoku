namespace SIMDoku.WinForms.Dialogs
{
	public interface IDialog
	{
		void NewRow<T>();
		void UpdateRow<T>(T row);
		void CloseDialog();

		void Clean();


	}
}
