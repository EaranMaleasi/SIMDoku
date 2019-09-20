using System;
using System.Collections.Generic;

namespace SIMDoku.WinForms.Dialogs
{
	public class DialogManager
	{
		private Dictionary<Type, IDialog> _RegisteredDialogs;
		private IDialog _CurrentDialog;

		public bool IsDialogOpen => _CurrentDialog != null;

		public void RegisterDialog<T, Form>(IDialog dialog)
		{
			_RegisteredDialogs.Add(typeof(T), dialog);
		}

		public bool OpenDialog<T>(T obj = default)
		{
			if (IsDialogOpen)
			{
				return false;
			}
			if (_RegisteredDialogs.TryGetValue(typeof(T), out IDialog dialog))
			{
				_CurrentDialog = dialog;
				if (obj == default)
				{
					dialog.NewRow<T>();
				}
				else
				{
					dialog.UpdateRow(obj);
				}
			}
			return true;
		}

		public void CloseCurrentDialog()
		{
			_CurrentDialog.CloseDialog();
			_CurrentDialog = null;
		}
	}
}