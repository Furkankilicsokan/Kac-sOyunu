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
	internal class Bomba : Cisim
	{
		public Bomba(int height, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			BringToFront();
			Image = Image.FromFile(@"Görseller/bomb.png");
			BackColor = Color.Transparent;
		}
	}
}
