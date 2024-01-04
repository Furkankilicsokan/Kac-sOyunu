/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */



using Kacıs.Library.Enum;
using System.Drawing;


namespace Kacıs.Library.Interface
{
	internal interface IHareket
	{

		Size HareketAlaniBoyutlari { get; }

		int HareketMesafesi { get; }

		/// <summary>
		/// Cismi hareket ettirir
		/// </summary>
		/// <param name="yon">Hangi yöne hareket edileceği</param>
		/// <returns>Cisim duvara çarparsa true döndürür</returns>
		bool HareketEt(Yon yon);


	}
}
