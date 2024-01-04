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
	internal class Tuzak : Cisim
	{
		public Tuzak(int height, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			BringToFront();

			BackColor = Color.Transparent;
		}
	}
}
