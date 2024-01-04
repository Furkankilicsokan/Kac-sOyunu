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
	internal class Sandık : Cisim
	{

		public Sandık(int height, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			BringToFront();
			Image = Image.FromFile(@"Görseller/heart.png");
			BackColor = Color.Transparent;
		}

	}
}
