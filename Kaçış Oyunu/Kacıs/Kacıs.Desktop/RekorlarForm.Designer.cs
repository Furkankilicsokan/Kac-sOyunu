namespace Kacıs.Desktop
{
	partial class RekorlarForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RekorlarForm));
			this.Rekorlar_listbox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Rekorlar_listbox
			// 
			this.Rekorlar_listbox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Rekorlar_listbox.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Rekorlar_listbox.FormattingEnabled = true;
			this.Rekorlar_listbox.ItemHeight = 31;
			this.Rekorlar_listbox.Location = new System.Drawing.Point(102, 172);
			this.Rekorlar_listbox.Name = "Rekorlar_listbox";
			this.Rekorlar_listbox.Size = new System.Drawing.Size(253, 314);
			this.Rekorlar_listbox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(141, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 50);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rekorlar";
			// 
			// RekorlarForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleTurquoise;
			this.ClientSize = new System.Drawing.Size(464, 670);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Rekorlar_listbox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RekorlarForm";
			this.Text = "Kaçış Oyunu";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox Rekorlar_listbox;
		private System.Windows.Forms.Label label1;
	}
}