/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */

using Kacıs.Library.Abstract;
using System.Drawing;

namespace Kacıs.Library.Concrete
{
	internal class Dusman : Cisim
	{
		public Dusman(int height, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			BringToFront();
			Image = Image.FromFile(@"Görseller/enemy.png");
			BackColor = Color.Transparent;

			Left = 1250;
			Top = 175;
		}
	}
}
