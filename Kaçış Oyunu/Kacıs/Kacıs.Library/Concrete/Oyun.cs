/*
 Bilişim Sistemleri Mühendisliği
 Nesneye Dayalı Programlama

 Furkan Kılıçsokan
 B221200380
 */

using Kacıs.Library.Enum;
using Kacıs.Library.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Kacıs.Library.Concrete
{
	public class Oyun : IOyun
	{

		#region Alanlar
		//Sürelerin belirlenmesi
		private readonly Timer _sandikDüsmeTimer = new Timer { Interval = 10000 };
		private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
		private readonly Timer _bombaDüsmeTimer = new Timer { Interval = 2000 };
		private readonly Timer _dusmanCıkmaTimer = new Timer { Interval = 2000 };
		private readonly Timer _dusmanHareketTimer = new Timer { Interval = 1000 };

		private TimeSpan _gecenSure;
		private readonly Panel _seviye_panel_bot;
		private readonly Label _puan_lbl, _can_lbl, _seviye_lbl, _oyuncu_lbl;
		private readonly PictureBox _pause_pb;
		private readonly PictureBox _heart_pb;
		private Karakter _karakter;
		private Zemin _zemin;
		private Bitis _bitis;
		private Sandık _sandık;
		private Bomba _bomba;
		private Dusman _dusman;
		private PictureBox _pause;

		int can = 3;
		int seviye = 1;
		int puan = 0;

		Random random = new Random();

		#endregion

		#region Olaylar
		public event EventHandler GecenSureDegisti;
		#endregion

		#region Özellikler
		public bool DevamEdiyorMu { get; private set; }
		public TimeSpan GecenSure
		{
			get => _gecenSure;
			private set
			{
				_gecenSure = value;

				GecenSureDegisti?.Invoke(this, EventArgs.Empty);
			}
		}
		#endregion

		#region Metotlar
		#endregion
		//Oyun sınıfına gönderilen parametrelerin alınması
		public Oyun(Panel seviye_panel_bot, Label can_lbl, Label oyuncu_lbl, Label seviye_lbl, Label puan_lbl, PictureBox pause_pb, PictureBox heart_pb)
		{
			_can_lbl = can_lbl;
			_oyuncu_lbl = oyuncu_lbl;
			_seviye_lbl = seviye_lbl;
			_puan_lbl = puan_lbl;
			_pause_pb = pause_pb;
			_heart_pb = heart_pb;
			_seviye_panel_bot = seviye_panel_bot;
			_bombaDüsmeTimer.Tick += BombaDüsmeTimer_Tick;
			_gecenSureTimer.Tick += GecenSureTimer_Tick;
			_sandikDüsmeTimer.Tick += SandikDüsmeTimer_Tick;
			_dusmanCıkmaTimer.Tick += DusmanCıkmaTimer_Tick;
			_dusmanHareketTimer.Tick += DusmanHareketTimer_Tick;
			
		}
		//Geçen süre tickin tutulması
		private void GecenSureTimer_Tick(object sender, EventArgs e)
		{
			GecenSure += TimeSpan.FromSeconds(1);
		}
		//Sandık düşme süresinin tickinin tutulması
		private void SandikDüsmeTimer_Tick(object sender, EventArgs e)
		{
			SandıkOlustur();
		}
		//Bomba düşme süresinin tickinin tutulması
		private void BombaDüsmeTimer_Tick(object sender, EventArgs e)
		{
			BombaOlustur();
			KarakterBombaKontrol();
		}
		//Düşman çıkma süresinin tickinin tutulması
		private void DusmanCıkmaTimer_Tick(object sender, EventArgs e)
		{
			DusmanCıkar();
		}
		//Düşman hareket etme süresinin tickinin tutulması
		private void DusmanHareketTimer_Tick(object sender, EventArgs e)
		{
			DusmanHareket();
			KarakterDusmanKontrol();
		}
		//Oyunu başlatan metot
		public void Baslat()
		{
			if (DevamEdiyorMu) return; //Oyun zaten devam ediyorsa bir şey yapmaz.

			DevamEdiyorMu = true;//Devam etmiyorsa oyunu başlatan fonksiyonları gerçekleştirir
			_pause_pb.Visible = false;
			KarakterOlustur();
			ZeminOlustur();
			TuzakOlustur();

			_gecenSureTimer.Start();
			_sandikDüsmeTimer.Start();
			_can_lbl.Text = can.ToString();
			_puan_lbl.Text = puan.ToString();
		}
		//P tuşuna basıldığında oyunu durduran metot
		public void Durdur()
		{
			if (DevamEdiyorMu)//Devam ediyor mu kontrol edip devam ediyorsa oyunu ve tüm timerları durdurur
			{
				_sandikDüsmeTimer.Stop();
				_gecenSureTimer.Stop();
				DevamEdiyorMu = false;
				if (seviye == 2)
				{
					_bombaDüsmeTimer.Stop();
				}
				if (seviye == 3)
				{
					_dusmanCıkmaTimer.Stop();
					_dusmanHareketTimer.Stop();
				}
				_pause_pb.Visible = true;
			}
			else//Eğer oyun zaten duruyorsa P ye basıldığında oyunu ve tüm timerları başlatır
			{
				_sandikDüsmeTimer.Start();
				_gecenSureTimer.Start();
				DevamEdiyorMu = true;
				_pause_pb.Visible = false;
				if (seviye == 2)
				{
					_bombaDüsmeTimer.Start();
				}
				if (seviye == 3)
				{
					_dusmanCıkmaTimer.Start();
					_dusmanHareketTimer.Start();
				}

				return;
			}
		}
		//Karakter oluşturma metodu
		private void KarakterOlustur()
		{
			_karakter = new Karakter(_seviye_panel_bot.Height, _seviye_panel_bot.Size);

			_seviye_panel_bot.Controls.Add(_karakter);
		}
		//Karakter hareketleri ve etkileşimleri kontrol metodu
		public void KarakteriHareket(Yon yon)
		{
			if (DevamEdiyorMu)
			{
				_karakter.HareketEt(yon);

				KarakterTuzakKontrol();
				KarakterSandikKontrol();
				KarakterBombaKontrol();
				KarakterDusmanKontrol();
				BitiseGeldiMi();
			}
			else return;
		}
		//Zemin oluşturma metodu
		private void ZeminOlustur()
		{
			int zeminGenisligi = 90;
			int zeminYuksekligi = 90;

			BitisOlustur();

			for (int i = 1; i <= 3; i++)
			{
				for (int j = 1; j <= 10; j++)
				{
					Zemin zemin = new Zemin(_seviye_panel_bot.Height, _seviye_panel_bot.Size);	
					

					int zeminLeft = 300 + ((j - 1) * (zeminGenisligi + 5));
					int zeminTop = 170 + ((i - 1) * (zeminYuksekligi + 5));

					zemin.Left = zeminLeft;
					zemin.Top = zeminTop;

					_seviye_panel_bot.Controls.Add(zemin);
					zemin.SendToBack();
				}
			}
		}
		//Tuzak oluşturma metodu
		private void TuzakOlustur()
		{
			int tuzakSayisi = 10;
			List<Tuzak> tuzaklar = new List<Tuzak>();
			
			//Rastegele tuzak resmi için random fonksiyonu
			Random random = new Random();
			//Tuzak resimleri
			Image tuzakResim1 = Image.FromFile(@"Görseller\flame.png");
			Image tuzakResim2 = Image.FromFile(@"Görseller\bear_trap.png");
			Image tuzakResim3 = Image.FromFile(@"Görseller\Spike_trap.png");

			for (int i = 0; i < tuzakSayisi; i++)
			{
				var tuzak = new Tuzak(_seviye_panel_bot.Height, _seviye_panel_bot.Size);
				
				//Rastegele tuzak için index seçimi
				int randomResim = random.Next(3); // 0, 1 veya 2
				//Rastgele tuzağın seçilmesi
				switch (randomResim)
				{
					case 0:
						tuzak.Image = tuzakResim1;
						break;
					case 1:
						tuzak.Image = tuzakResim2;
						break;
					case 2:
						tuzak.Image = tuzakResim3;
						break;
				}
				
				

				RastgeleKonumlandir(tuzak, _seviye_panel_bot);
				tuzaklar.Add(tuzak);
				_seviye_panel_bot.Controls.Add(tuzak);
			}

			// Tuzakların konumlarını kontrol et ve çakışma durumunda düzelt
			KontrolEtVeDuzelt(tuzaklar);
		}
		//Tuzakların rastgele konumlara koyulması metodu
		private void RastgeleKonumlandir(Control control, Panel zeminPanel)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());

			int zeminGenisligi = 90;
			int zeminYuksekligi = 90;


		
			int zeminIndex = random.Next(0, zeminPanel.Controls.Count);
			Control zemin = zeminPanel.Controls[zeminIndex];

			control.Left = zemin.Left + random.Next(0, zeminGenisligi - control.Width);
			control.Top = zemin.Top + random.Next(0, zeminYuksekligi - control.Height);

			if (control.Left == 205)
			{
				RastgeleKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
			if (control.Left == 50)
			{
				RastgeleKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
			if (control.Left == 1250)
			{
				RastgeleKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
		}
		//Tuzakların üst üste geldiği durumları düzeltmek için kontrol yapan ve üst üste gelenleri düzelten metod
		private void KontrolEtVeDuzelt(List<Tuzak> tuzaklar)
		{
			foreach (var tuzak in tuzaklar)
			{
				foreach (var digerTuzak in tuzaklar)
				{
					if (tuzak != digerTuzak && tuzak.Bounds.IntersectsWith(digerTuzak.Bounds))
					{
						// Çakışma durumunda tuzağın konumunu yeniden ayarla
						RastgeleKonumlandir(tuzak, _seviye_panel_bot);
						KontrolEtVeDuzelt(tuzaklar); // Yeniden kontrol et
					}
				}
			}
		}
		//Karakterin tuzakla etkileşimini kontrol eden metot
		private void KarakterTuzakKontrol() 
		{
			// Karakterin konumu ile tuzakların konumunu kontrol et
			foreach (Control control in _seviye_panel_bot.Controls)
			{
				if (control is Tuzak && _karakter.Bounds.IntersectsWith(control.Bounds))
				{
					//Karakter tuzakla aynı konuma geldiyse canını azaltan metot
					CanAzalt();
					Tuzak tuzak = control as Tuzak;
					tuzak.BringToFront();
					_karakter.BringToFront();
				}
			}
		}
		//Karakterin canını azaltan metat
		private void CanAzalt()
		{
			_heart_pb.Image = Image.FromFile(@"Görseller/-heart.png");
			_heart_pb.Visible = true;
			can--;
			_can_lbl.Text = can.ToString();

			if (can == 0)
			{
				OyunBitti();

				DevamEdiyorMu = false;
			}
		}
		//Sandık oluşturan metot
		private void SandıkOlustur()
		{
			Sandık sandik = new Sandık(_seviye_panel_bot.Height, _seviye_panel_bot.Size);

			// Zemin nesnelerini bul
			var zeminNesneleri = _seviye_panel_bot.Controls.OfType<Zemin>().ToArray();

			if (zeminNesneleri.Length > 0)
			{
				// Rastgele bir zemin seç
				Zemin rastgeleZemin = zeminNesneleri[random.Next(zeminNesneleri.Length)];

				// Sandığı seçilen zeminin içine yerleştir
				int maxX = rastgeleZemin.Right - sandik.Width;
				int maxY = rastgeleZemin.Bottom - sandik.Height;

				sandik.Left = random.Next(rastgeleZemin.Left, maxX + 1);
				sandik.Top = random.Next(rastgeleZemin.Top, maxY + 1);

				_seviye_panel_bot.Controls.Add(sandik);
				sandik.BringToFront();
			}
		}
		//Sandık ile karakterin etkileşimini kontrol eden metot
		private void KarakterSandikKontrol()
		{
			foreach (Control control in _seviye_panel_bot.Controls)
			{
				if (control is Sandık && _karakter.Bounds.IntersectsWith(control.Bounds))
				{

					double rastgeleOlasilik = random.NextDouble(); // 0 ile 1 arasında rastgele bir sayı

					if (rastgeleOlasilik < 0.8) // %80 ihtimalle can arttırma
					{
						_karakter.BringToFront();	
						CanYükselt();
					}
					else // %20 ihtimalle can azaltma
					{
						_karakter.BringToFront();
						CanAzalt();
					}
					_karakter.BringToFront();
					_seviye_panel_bot.Controls.Remove(control);
				}
				
			}
		}
		//Karakterin canını arttıran metot
		private void CanYükselt()
		{
			if (can <= 4)
			{
				_heart_pb.Image = Image.FromFile(@"Görseller/+heart.png");
				_heart_pb.Visible = true;
				can++;
				_can_lbl.Text = can.ToString();
			}
		}
		//Bomba oluşturma metodu
		private void BombaOlustur()
		{
			// Mevcut bombaları temizle
			foreach (Control control in _seviye_panel_bot.Controls.OfType<Bomba>().ToList())
			{
				_seviye_panel_bot.Controls.Remove(control);
			}

			// Rastgele 10 zemin seçip bomba yerleştir
			int bombaSayisi = 10;
			List<Bomba> bombalar = new List<Bomba>();

			for (int i = 0; i < bombaSayisi; i++)
			{
				var bomba = new Bomba(_seviye_panel_bot.Height, _seviye_panel_bot.Size)
				{
					Image = Image.FromFile(@"Görseller\bomb.png")
				};

				RastgeleKonumlandir(bomba, _seviye_panel_bot);
				bombalar.Add(bomba);
				_seviye_panel_bot.Controls.Add(bomba);
				bomba.BringToFront();
			}

			// Bombaların konumlarını kontrol et ve çakışma durumunda düzelt
			BombaKontrolEtVeDuzelt(bombalar);
		}
		//Bombanın rastgele konumlandırılması metodu
		private void RastgeleBombaKonumlandir(Control control, Panel zeminPanel)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());

			int zeminGenisligi = 90;
			int zeminYuksekligi = 90;



			int zeminIndex = random.Next(0, zeminPanel.Controls.Count);
			Control zemin = zeminPanel.Controls[zeminIndex];

			control.Left = zemin.Left + random.Next(0, zeminGenisligi - control.Width);
			control.Top = zemin.Top + random.Next(0, zeminYuksekligi - control.Height);

			if (control.Left == 205)
			{
				RastgeleBombaKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
			if (control.Left == 50)
			{
				RastgeleBombaKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
			if (control.Left == 1250)
			{
				RastgeleBombaKonumlandir(control, zeminPanel); // Özel durum için tekrar rastgele konumlandırma
				return;
			}
		}
		//Bombaların üst üste gelip gelmediğini kontrol eden metot
		private void BombaKontrolEtVeDuzelt(List<Bomba> bombalar)
		{
			foreach (var bomba in bombalar)
			{
				foreach (var digerBomba in bombalar)
				{
					if (bomba != digerBomba && bomba.Bounds.IntersectsWith(digerBomba.Bounds))
					{
						// Çakışma durumunda bombanın konumunu yeniden ayarla
						RastgeleBombaKonumlandir(bomba, _seviye_panel_bot);
						BombaKontrolEtVeDuzelt(bombalar); // Yeniden kontrol et
					}
				}
			}
		}
		//Karakter ve bombanın etkileşim durumunu kontrol eden metot
		private void KarakterBombaKontrol() 
		{
			foreach (Control control in _seviye_panel_bot.Controls)
			{
				if (control is Bomba && _karakter.Bounds.IntersectsWith(control.Bounds))
				{
					CanAzalt();
					_karakter.BringToFront();
					_seviye_panel_bot.Controls.Remove(control);

				}
			}
		}
		//Düşmanları oluşturan metot
		private void DusmanCıkar()
		{
			//Düşmanlaın astgele konumlada oluşması için random sayı ürretme
			int satirSayisi = random.Next(0, 3);
			_dusman = new Dusman(_seviye_panel_bot.Height, _seviye_panel_bot.Size);
			//Düşmanların zeminden taşmaması için kontrol
			if (satirSayisi == 0) {
				_dusman.Top = _dusman.Top - 5;
			}
			else if (satirSayisi == 1) {
				_dusman.Top = _dusman.Top + _dusman.Width * satirSayisi;
			}
			else
			{
				_dusman.Top = (_dusman.Top + 5) + _dusman.Width * satirSayisi;
			}
			_seviye_panel_bot.Controls.Add(_dusman);
			_dusman.BringToFront();
		}
		//Karakter ve düşmaların etkileşim durumunu kontrol eden metot
		private void KarakterDusmanKontrol()
		{
			foreach (Control control in _seviye_panel_bot.Controls)
			{
				if (control is Dusman && _karakter.Bounds.IntersectsWith(control.Bounds))
				{
					CanAzalt();
					_heart_pb.Visible = false;
					_karakter.BringToFront();
					_dusman.BringToFront();
					_seviye_panel_bot.Controls.Remove(control);
				}
			}
		}
		//Düşmanların hareketlerini gerçekleştiren metot
		private void DusmanHareket()
		{
			foreach (Control control in _seviye_panel_bot.Controls.OfType<Dusman>().ToList())
			{

				control.Left -= control.Width + 5;

				if (control.Left < 125) // Zeminlerin dışına çıkmışsa düşmanı kaldır.
				{
					_seviye_panel_bot.Controls.Remove(control);
				}
			}
		}
		//Biriş oluşturan metot
		private void BitisOlustur()
		{
			_bitis = new Bitis(_seviye_panel_bot.Height, _seviye_panel_bot.Size);

			_seviye_panel_bot.Controls.Add(_bitis);
		}
		//Bitişe gelinip gelinmediğini kontrol eden metot
		private void BitiseGeldiMi()
		{
			if (_karakter.Location.X == _bitis.Location.X)
			{
				PuanHesapla();
				DevamEdiyorMu = false;
				_sandikDüsmeTimer.Stop();
				_gecenSureTimer.Stop();
				SeviyeAtla();

			}
		}
		//Seviye Atlatan metot
		private void SeviyeAtla()
		{

			seviye++;
			Sıfırla();
			switch (seviye)
			{
				case 2:
					YeniSeviye();
					_bombaDüsmeTimer.Start();
					break;
				case 3:
					YeniSeviye();
					_bombaDüsmeTimer.Stop();
					_dusmanCıkmaTimer.Start();
					_dusmanHareketTimer.Start();
					break;
				case 4:
					OyunBitti();
					break;
			}
		}
		//Yeni seviyeye atlandığında gerekli olan timerları başlatan, karakteri ve zemini oluşturan metot
		private void YeniSeviye()
		{
			KarakterOlustur();
			ZeminOlustur();

			DevamEdiyorMu = true;
			can++;
			_gecenSureTimer.Start();
			_sandikDüsmeTimer.Start();
			_can_lbl.Text = can.ToString();
			_seviye_lbl.Text = seviye.ToString();
		}
		//Seviye atlandığında diğer seviyeye geçmeden önce eski öğeleri kaldıran metot
		private void Sıfırla()
		{
			_seviye_panel_bot.Controls.Remove(_karakter); // Karakteri kaldır

			// Zemin nesnelerini bul ve kaldır
			foreach (Control control in _seviye_panel_bot.Controls.OfType<Zemin>().ToList())
			{
				_seviye_panel_bot.Controls.Remove(control);
			}

			// Tuzak nesnelerini bul ve kaldır
			if (seviye == 2)
			{
				foreach (Control control in _seviye_panel_bot.Controls.OfType<Tuzak>().ToList())
				{
					_seviye_panel_bot.Controls.Remove(control);
				}
			}
			//Bombaları kaldır
			if (seviye == 3)
			{
				foreach (Control control in _seviye_panel_bot.Controls.OfType<Bomba>().ToList())
				{
					_seviye_panel_bot.Controls.Remove(control);
				}
			}
			//Düşmanları kaldır
			if (seviye == 4)
			{
				foreach (Control control in _seviye_panel_bot.Controls.OfType<Dusman>().ToList())
				{
					_seviye_panel_bot.Controls.Remove(control);
				}
			}

			foreach (Control control in _seviye_panel_bot.Controls.OfType<Sandık>().ToList())
			{
				_seviye_panel_bot.Controls.Remove(control);
			}

			_seviye_panel_bot.Controls.Remove(_bitis);

		}
		//Skorların tutulduğu .txt dosyasının oluşturulması
		private const string YuksekSkorDosyaAdı = "yüksekskorlar.txt";

		private List<string> yuksekSkorlar;
		//Skorları kaydeden metot
		public void YuksekSkorlarıKaydet(string oyuncuAd, int skor)
		{
			if (yuksekSkorlar == null)
			{
				yuksekSkorlar = new List<string>();
			}

			yuksekSkorlar.Add($"{oyuncuAd}: {skor}");

			using (StreamWriter writer = new StreamWriter(YuksekSkorDosyaAdı, true)) // true: dosyaya ekleme modu
			{
				writer.WriteLine($"{oyuncuAd}: {skor}");
			}
		}
		//Puan hesaplayan metot
		private void PuanHesapla()
		{
			puan = can * 500 + (1000 - _gecenSure.Seconds);
			_puan_lbl.Text = puan.ToString();
			_puan_lbl.Visible = true;
		}
		//Timerları durduran metot
		private void TimerStop()
		{
			_bombaDüsmeTimer.Stop();
			_gecenSureTimer.Stop();
			_sandikDüsmeTimer.Stop();
			_dusmanCıkmaTimer.Stop();
			_dusmanHareketTimer.Stop();
		}
		//Oyun bittiğinde sonuca göre mesaj gösteren ve uygulamayı kapatan metot
		private void OyunBitti()
		{
			TimerStop();
			PuanHesapla();
			YuksekSkorlarıKaydet(_oyuncu_lbl.Text, puan);
			if (can == 0)
			{
				MessageBox.Show("Hüsran! Canların bitti. Yenilgiye alış, çünkü zafer senin için değil.");
			}
			else
			{
				MessageBox.Show("Zafer! Rakipleri ezip geçtin. Yenilmezliğin tadını çıkar, çünkü zafer senin. Devam et, şampiyon!");
			}
			Application.Exit();
		}
	}
}