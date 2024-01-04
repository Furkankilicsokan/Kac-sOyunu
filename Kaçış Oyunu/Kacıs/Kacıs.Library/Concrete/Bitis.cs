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
	internal class Bitis : Cisim
	{
		public Bitis(int height, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
		{
			BringToFront();
			Image = Image.FromFile(@"Görseller\finish.png");
			BackColor = Color.Transparent;
			Width = 90;
			Height = 540;
			Top = 265;
			Left = 1250;
		}
	}
}
