/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */

using System;
using System.Windows.Forms;
using Kacıs.Library.Concrete;
using Kacıs.Library.Enum;


namespace Kacıs.Desktop
{
	public partial class SeviyelerForm : Form
	{
		private readonly Oyun _oyun;
		public string oyuncuAdı;


		public SeviyelerForm()
		{
			InitializeComponent();
			_oyun = new Oyun(seviye_panel_bot, can_lbl, oyuncu_lbl, seviye_lbl, puan_lbl, pause_pb, heart_pb);
			_oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
		}
		//Formun yüklenmesi ve oyunun başlaması
		private void SeviyelerForm_Load(object sender, EventArgs e)
		{
			_oyun.Baslat();

			oyuncu_lbl.Text = oyuncuAdı;
		}
		//Formda tuş bilgilerinin alınması
		private void SeviyelerForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Right:
					_oyun.KarakteriHareket(Yon.Sag);
					break;
				case Keys.Left:
					_oyun.KarakteriHareket(Yon.Sol);
					break;
				case Keys.Up:
					_oyun.KarakteriHareket(Yon.Yukari);
					break;
				case Keys.Down:
					_oyun.KarakteriHareket(Yon.Asagi);
					break;
				case Keys.P:
					_oyun.Durdur();
					break;
			}
		}
		//Oyun süresinin yazılması
		private void Oyun_GecenSureDegisti(object sender, EventArgs e)
		{
			sure_lbl.Text = _oyun.GecenSure.ToString(@"m\:ss");
		}
	}
}
