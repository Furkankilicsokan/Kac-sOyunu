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
	internal class Zemin : Cisim
	{
		public Zemin(int panelBoy, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			Image = Image.FromFile(@"Görseller/ground.png");
		}
		
	}
}
