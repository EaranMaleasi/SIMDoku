namespace SIMDoku.WinForms.Controls
{
	partial class TagControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.tag1 = new SIMDoku.WinForms.Controls.Tag();
			this.SuspendLayout();
			// 
			// tag1
			// 
			this.tag1.Location = new System.Drawing.Point(123, 117);
			this.tag1.Name = "tag1";
			this.tag1.Size = new System.Drawing.Size(157, 46);
			this.tag1.TabIndex = 0;
			this.tag1.TagText = null;
			// 
			// TagControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tag1);
			this.Name = "TagControl";
			this.Size = new System.Drawing.Size(438, 310);
			this.ResumeLayout(false);

		}

		#endregion

		private Tag tag1;
	}
}
