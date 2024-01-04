namespace Kacıs.Desktop
{
	partial class MenuForm
	{
		/// <summary>
		///Gerekli tasarımcı değişkeni.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///Kullanılan tüm kaynakları temizleyin.
		/// </summary>
		///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer üretilen kod

		/// <summary>
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
			this.menu_panel_top = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.menu_panel_bottom = new System.Windows.Forms.Panel();
			this.rekor_btn = new System.Windows.Forms.Button();
			this.tus_btn = new System.Windows.Forms.Button();
			this.basla_btn = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menu_panel_ad = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.menu_panel_top.SuspendLayout();
			this.menu_panel_bottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menu_panel_ad.SuspendLayout();
			this.SuspendLayout();
			// 
			// menu_panel_top
			// 
			this.menu_panel_top.BackColor = System.Drawing.Color.Azure;
			this.menu_panel_top.Controls.Add(this.label1);
			this.menu_panel_top.Dock = System.Windows.Forms.DockStyle.Top;
			this.menu_panel_top.Location = new System.Drawing.Point(0, 0);
			this.menu_panel_top.Name = "menu_panel_top";
			this.menu_panel_top.Size = new System.Drawing.Size(1482, 170);
			this.menu_panel_top.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(536, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(557, 38);
			this.label1.TabIndex = 0;
			this.label1.Text = "2023 - 2024 Güz Dönemi NDP Proje Ödevi\r\n";
			// 
			// menu_panel_bottom
			// 
			this.menu_panel_bottom.BackColor = System.Drawing.Color.PaleTurquoise;
			this.menu_panel_bottom.Controls.Add(this.rekor_btn);
			this.menu_panel_bottom.Controls.Add(this.tus_btn);
			this.menu_panel_bottom.Controls.Add(this.basla_btn);
			this.menu_panel_bottom.Controls.Add(this.label5);
			this.menu_panel_bottom.Controls.Add(this.label4);
			this.menu_panel_bottom.Controls.Add(this.label3);
			this.menu_panel_bottom.Controls.Add(this.pictureBox6);
			this.menu_panel_bottom.Controls.Add(this.pictureBox2);
			this.menu_panel_bottom.Controls.Add(this.pictureBox1);
			this.menu_panel_bottom.Controls.Add(this.menu_panel_ad);
			this.menu_panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menu_panel_bottom.Location = new System.Drawing.Point(0, 170);
			this.menu_panel_bottom.Name = "menu_panel_bottom";
			this.menu_panel_bottom.Size = new System.Drawing.Size(1482, 558);
			this.menu_panel_bottom.TabIndex = 1;
			// 
			// rekor_btn
			// 
			this.rekor_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rekor_btn.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rekor_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rekor_btn.BackgroundImage")));
			this.rekor_btn.Location = new System.Drawing.Point(43, 385);
			this.rekor_btn.Name = "rekor_btn";
			this.rekor_btn.Size = new System.Drawing.Size(60, 60);
			this.rekor_btn.TabIndex = 12;
			this.rekor_btn.UseVisualStyleBackColor = false;
			this.rekor_btn.Click += new System.EventHandler(this.rekor_btn_Click_1);
			// 
			// tus_btn
			// 
			this.tus_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tus_btn.BackColor = System.Drawing.Color.PaleTurquoise;
			this.tus_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tus_btn.BackgroundImage")));
			this.tus_btn.Location = new System.Drawing.Point(43, 298);
			this.tus_btn.Name = "tus_btn";
			this.tus_btn.Size = new System.Drawing.Size(60, 60);
			this.tus_btn.TabIndex = 11;
			this.tus_btn.UseVisualStyleBackColor = false;
			this.tus_btn.Click += new System.EventHandler(this.tus_btn_Click_1);
			// 
			// basla_btn
			// 
			this.basla_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.basla_btn.BackColor = System.Drawing.Color.PaleTurquoise;
			this.basla_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("basla_btn.BackgroundImage")));
			this.basla_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.basla_btn.Location = new System.Drawing.Point(43, 215);
			this.basla_btn.Name = "basla_btn";
			this.basla_btn.Size = new System.Drawing.Size(60, 60);
			this.basla_btn.TabIndex = 10;
			this.basla_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.basla_btn.UseVisualStyleBackColor = false;
			this.basla_btn.Click += new System.EventHandler(this.basla_btn_Click_1);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(153, 398);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(367, 28);
			this.label5.TabIndex = 9;
			this.label5.Text = "En yüksek skorları öğrenmek için tıklayın.";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(153, 311);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(264, 28);
			this.label4.TabIndex = 8;
			this.label4.Text = "Tuş takımı bilgisi için tıklayın.";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(153, 215);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(383, 56);
			this.label3.TabIndex = 7;
			this.label3.Text = "Oyuna başlamak için kullanıcı adınızı girin\r\nardından ENTER tuşuna veya butona ba" +
    "sın.\r\n";
			// 
			// pictureBox6
			// 
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(158, 15);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(174, 202);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 6;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(1298, 278);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(123, 102);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(1298, 386);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(123, 127);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// menu_panel_ad
			// 
			this.menu_panel_ad.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.menu_panel_ad.BackColor = System.Drawing.Color.SkyBlue;
			this.menu_panel_ad.Controls.Add(this.textBox1);
			this.menu_panel_ad.Controls.Add(this.label2);
			this.menu_panel_ad.Location = new System.Drawing.Point(563, 234);
			this.menu_panel_ad.Name = "menu_panel_ad";
			this.menu_panel_ad.Size = new System.Drawing.Size(356, 90);
			this.menu_panel_ad.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(185, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(164, 25);
			this.textBox1.TabIndex = 1;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(27, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "Kullanıcı Adı:";
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1482, 728);
			this.Controls.Add(this.menu_panel_bottom);
			this.Controls.Add(this.menu_panel_top);
			this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MenuForm";
			this.Text = "Kaçış Oyunu";
			this.Load += new System.EventHandler(this.MenuForm_Load);
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menu_panel_top.ResumeLayout(false);
			this.menu_panel_top.PerformLayout();
			this.menu_panel_bottom.ResumeLayout(false);
			this.menu_panel_bottom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menu_panel_ad.ResumeLayout(false);
			this.menu_panel_ad.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel menu_panel_top;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel menu_panel_bottom;
		private System.Windows.Forms.Panel menu_panel_ad;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button basla_btn;
		private System.Windows.Forms.Button rekor_btn;
		private System.Windows.Forms.Button tus_btn;
	}
}

