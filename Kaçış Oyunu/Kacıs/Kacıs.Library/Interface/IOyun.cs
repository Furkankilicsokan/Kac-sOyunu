/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */



using Kacıs.Library.Enum;
using System;

namespace Kacıs.Library.Interface
{
	internal interface IOyun
	{

		event EventHandler GecenSureDegisti;

		bool DevamEdiyorMu { get; }
		TimeSpan GecenSure { get; }

		void Baslat();
		void Durdur();
		void KarakteriHareket(Yon yon);

	}
}