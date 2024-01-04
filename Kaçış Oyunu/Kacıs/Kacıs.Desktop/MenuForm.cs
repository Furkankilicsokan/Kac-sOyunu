/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */

using System;
using System.Windows.Forms;

namespace Kacıs.Desktop
{
	public partial class MenuForm : Form
	{

		public SeviyelerForm seviyelerForm = new SeviyelerForm();
		public MenuForm()
		{
			InitializeComponent();
		}

		private void MenuForm_Load(object sender, EventArgs e)
		{

		}
		//Oyunu başlatmak için başla butonu kullanımı
		private void basla_btn_Click_1(object sender, EventArgs e)
		{
			seviyelerForm.oyuncuAdı = textBox1.Text;
			seviyelerForm.Show();

			this.Hide();
		}
		//Tus bilgileri formunu açan buton kullanımı
		private void tus_btn_Click_1(object sender, EventArgs e)
		{
			BilgiForm bilgiForm = new BilgiForm();
			bilgiForm.Show();
		}
		//Rekorlar formunu açan buton kullanımı
		private void rekor_btn_Click_1(object sender, EventArgs e)
		{
			RekorlarForm rekorlarForm = new RekorlarForm();
			rekorlarForm.Show();
		}
		//Kullanıcı adı alındığında enter ile oyun başlatma
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					seviyelerForm.oyuncuAdı = textBox1.Text;
					seviyelerForm.Show();

					this.Hide();
					break;
				default: break;
			}
		}
	}
}
