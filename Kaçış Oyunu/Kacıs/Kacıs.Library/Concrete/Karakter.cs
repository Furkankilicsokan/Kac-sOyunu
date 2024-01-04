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
	internal class Karakter : Cisim
	{
		public Karakter(int panelBoy, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			Image = Image.FromFile(@"Görseller/character.png");
			HareketMesafesi = Width + 5;
			Top = 265;
			Left = 205;
			BringToFront();
		}
	}
}
