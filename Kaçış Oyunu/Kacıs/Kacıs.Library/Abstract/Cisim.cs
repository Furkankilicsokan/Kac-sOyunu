/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */

using Kacıs.Library.Interface;
using Kacıs.Library.Enum;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace Kacıs.Library.Abstract
{
	internal abstract class Cisim : PictureBox, IHareket
	{
		public Size HareketAlaniBoyutlari { get; }

		public int HareketMesafesi { get; protected set; }

		protected Cisim(Size hareketAlaniBoyutlari) 
		{
			HareketAlaniBoyutlari = hareketAlaniBoyutlari;
			Size = new Size(90, 90);
			SizeMode = PictureBoxSizeMode.AutoSize; 
		}

		public bool HareketEt(Yon yon)
		{
			switch (yon)
			{
				case Yon.Sag:
					return SagaHareketEttir();
				case Yon.Sol:
					return SolaHareketEttir();
				case Yon.Asagi:
					return AsagiHareketEttir();
				case Yon.Yukari:
					return YukariHareketEttir();
				default:
					throw new ArgumentOutOfRangeException(nameof(yon), yon, null);
			}
		}
		//Yukarı hareket metodu
		private bool YukariHareketEttir()
		{
			if (Top == 0 || Top - HareketMesafesi < 170) { return true; }
			else
			{
				var yeniTop = Top - HareketMesafesi;
				var tasacakMi = yeniTop < 90;
				Top = tasacakMi ? 75 : (yeniTop < 170 ? 170 : yeniTop);

				return Top == 95;
			}
		}
		//Aşağı hareket metodu
		private bool AsagiHareketEttir()
		{
			if (Bottom == HareketAlaniBoyutlari.Height - 95) { return true; }

			else
			{
				var yeniBottom = Bottom + HareketMesafesi;
				var tasacakMi = Bottom > HareketAlaniBoyutlari.Height - 95;
				var bottom = tasacakMi ? HareketAlaniBoyutlari.Height - 78 : (yeniBottom > 450 ? 450 : yeniBottom);
				Top = bottom - Height;
				return Bottom == HareketAlaniBoyutlari.Height - 95;
			}

		}
		//Sola hareket metodu
		private bool SolaHareketEttir()
		{
			if (Left == 0) { return true; }

			else
			{
				var yeniLeft = Left - HareketMesafesi;
				var tasacakMi = yeniLeft < 0;
				Left = tasacakMi ? 15 : yeniLeft;
				return Left == 0;
			}
		}
		//Sağa hareket metodu
		private bool SagaHareketEttir()
		{
			if (Right == HareketAlaniBoyutlari.Width - 45) { return true; }
			else
			{
				var yeniRight = Right + HareketMesafesi;
				var tasacakMi = yeniRight > HareketAlaniBoyutlari.Width - 45;
				var right = tasacakMi ? HareketAlaniBoyutlari.Width - 101 : yeniRight;
				Left = right - Width;

				return Right == HareketAlaniBoyutlari.Width - 45;
			}
		}
	}
}
