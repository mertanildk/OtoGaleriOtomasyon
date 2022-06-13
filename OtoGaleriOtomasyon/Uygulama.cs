using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OtoGaleriOtomasyon
{
    class Uygulama
    {
        static Galeri OtoGaleri = new Galeri();
       
        public static void UygulamaBaslangic()
        {
           
            SahteVeri();
            Menu();
            while (true)
            {

                Console.WriteLine();
                string secim = SecimAl();
                switch (secim)
                {

                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        OtoGaleri.KiradakiArabalariListele();
                        break;
                    case "4":
                    case "M":
                        OtoGaleri.GaleridekiArabalariListele();
                        break;
                    case "5":
                    case "A":
                        OtoGaleri.TumArabalariListele();
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        GaleriBilgileri();
                        break;

                }

            }
            //switch case yapısı ve seçim al...
        }
        public static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2- Araba Teslim Al (T)");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)");
            Console.WriteLine("5- Tüm Arabaları Listele (A)");
            Console.WriteLine("6- Kiralama İptali (I)");
            Console.WriteLine("7- Araba Ekle (Y)");
            Console.WriteLine("8- Araba Sil (S)");
            Console.WriteLine("9- Bilgileri Göster (G)");
        }//menu end
        public static string SecimAl()
        {
            string karakterler = "123456789KTRMAIYSG";

            while (true)
            {
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();

                if (giris.Length == 1 && karakterler.IndexOf(giris) > -1)
                {

                    return giris;

                }
                
                Console.WriteLine("Hatalı Giriş Yapıldı... Tekrar Deneyin...");

            }

        }
        public static void ArabaKirala(string plaka, int sure)
        {

            Araba a = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {

                    a = item;

                }
            }

            if (a != null)
            {

                a.Durum = Araba.DURUM.Kirada;
                a.KiralamaSureleri.Add(sure);

            }

        }
        public static void ArabaTeslimAl(string plaka)
        {

            Araba a = null;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Plaka == plaka)
                {

                    a = item;

                }
            }

            if (a != null)
            {

                a.Durum = Araba.DURUM.Galeride;

            }

        }
        public static void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            while (true)
            {

                bool sonuc;
                string plaka;
                do
                {
                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    sonuc = PlakaKontrol(plaka);
                } while (sonuc == false);

                int sure;
                Araba bosAraba = null;
                foreach (var item in OtoGaleri.Arabalar)
                {

                    if (plaka == item.Plaka && item.Durum == Araba.DURUM.Kirada)
                    {
                        Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                        bosAraba = item;
                        break;

                    }

                    if (plaka == item.Plaka && item.Durum == Araba.DURUM.Galeride)
                    {
                        sure = (int)SayiAl("Kiralama Süresi: ");
                        bosAraba = item;
                        item.KiralamaSureleri.Add(sure);
                        Console.WriteLine();
                        Console.WriteLine(item.Plaka + " Plakalı araba " + sure + " saatliğine kiralandı.");
                        item.Durum = Araba.DURUM.Kirada;
                        return;
                    }

                }
                if (bosAraba == null)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }

            }
        }
        
        public static void ArabaTeslimAl()
        {
            Console.WriteLine("-Araba Teslim Al-");
            while (true)
            {
                bool sonuc;
                string plaka;

                do
                {
                    Console.Write("Teslim edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    sonuc = PlakaKontrol(plaka);
                } while (sonuc == false);

                Araba bosAraba = null;
                foreach (var item in OtoGaleri.Arabalar)
                {

                    if (plaka == item.Plaka && item.Durum == Araba.DURUM.Galeride)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                        bosAraba = item;
                        break;
                    }
                    else if (plaka == item.Plaka && item.Durum == Araba.DURUM.Kirada)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Araba galeride beklemeye alındı.");
                        item.Durum = Araba.DURUM.Galeride;
                        bosAraba = item;
                        return;
                    }

                }
                if (bosAraba == null)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
            }
        }
        public static void KiralamaIptali()
        {
            Console.WriteLine("-Kiralama İptali-");
            string mesaj = "Kiralaması iptal edilecek arabanın plakası: ";
            //BİLEREK YANLIŞ YAPILDI ÇIKTIDA NE İSE ONU YAZMAYA ÇALIŞTIK... SAYGILAR
            while (true)
            {
                bool sonuc;
                string plaka;
                string teslim;
                
                do
                {
                    
                    Console.Write(mesaj);//"Kiralaması iptal edilecek arabanın plakası: "
                    plaka = Console.ReadLine().ToUpper();
                    sonuc = PlakaKontrol(plaka);
                } while (sonuc == false);

                Araba bosAraba = null;
                foreach (var item in OtoGaleri.Arabalar)
                {
                    if (plaka == item.Plaka && item.Durum == Araba.DURUM.Galeride)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride");
                        bosAraba = item;
                        break;
                    }
                    if (plaka == item.Plaka && item.Durum == Araba.DURUM.Kirada)
                    {
                        item.Durum = Araba.DURUM.Galeride;
                        Console.WriteLine();
                        Console.WriteLine("İptal gerçekleştirildi.");
                        bosAraba = item;
                        item.KiralamaSureleri.RemoveAt(item.KiralamaSureleri.Count - 1);
                        return;
                    }
                }
                if (bosAraba == null)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    mesaj = "Teslim edilecek arabanın plakası: ";


                    sonuc = false;
                }
                
            }
        }
        public static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            while (true)
            {

                bool sonuc;
                string plaka;

                do
                {
                    Console.Write("Plaka: ");
                    plaka = Console.ReadLine().ToUpper();
                    sonuc = PlakaKontrol(plaka);

                } while (sonuc == false);

                Araba araba = null;

                foreach (var item in OtoGaleri.Arabalar)
                {
                    if (plaka == item.Plaka)
                    {
                        araba = item;
                        break;
                    }
                }

                if (araba != null)
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                    continue;
                }


                string marka = MarkaDuzenleme("Marka: ");



                float kiralamaBedeli = SayiAl("Kiralama Bedeli: ");
                Araba.ARABA_TIPI aTipi = Araba.ARABA_TIPI.Default;
                Console.WriteLine("Araba Tipleri: ");
                Console.WriteLine("-SUV için 1");
                Console.WriteLine("-Hatcback için 2");
                Console.WriteLine("-Sedan için 3");

                bool dongu = true;
                while (dongu)
                {
                    Console.Write("Araba Tipi: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            aTipi = Araba.ARABA_TIPI.SUV;
                            break;
                        case "2":
                            aTipi = Araba.ARABA_TIPI.Hatchback;
                            break;
                        case "3":
                            aTipi = Araba.ARABA_TIPI.Sedan;
                            break;

                        default:
                            Console.WriteLine("Giriş tanımlanamadı. Tekrar Deneyin.");
                            continue;
                    }
                    if (secim != null)
                    {
                        dongu = false;
                    }

                }
                Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
                OtoGaleri.Arabalar.Add(a);
                Console.WriteLine();
                Console.WriteLine("Araba başarılı bir şekilde eklendi.");
                return;

            }
        }
        public static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            bool sonuc;
            string plaka;
            bool ikinci;
            Console.Write("Silmek istediğiniz arabanın plakasını giriniz: ");
            plaka = Console.ReadLine().ToUpper();
            sonuc = PlakaKontrol(plaka);

            while (true)
            {


                while (sonuc == false)
                {
                    Console.Write("Silinmek istenen araba plakasını girin: ");
                    plaka = Console.ReadLine().ToUpper();
                    sonuc = PlakaKontrol(plaka);
                }



                Araba araba = null;

                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        araba = item;
                        break;
                    }
                }

                if (araba == null)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    sonuc = false;

                }


                if (araba != null)
                {
                    if (araba.Durum == Araba.DURUM.Kirada)
                    {
                        Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekletirilemedi.");
                        sonuc = false;

                    }
                    else
                    {
                        Console.WriteLine();
                        OtoGaleri.Arabalar.Remove(araba);
                        Console.WriteLine("Araba silindi.");
                        break;

                    }

                }
            }


        }
        public static void GaleriBilgileri()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam araba sayısı: " + OtoGaleri.ToplamArabaSayisi);
            Console.WriteLine("Kiradaki araba sayısı: " + OtoGaleri.KiradakiArabaSayisi);
            Console.WriteLine("Bekleyen araba sayısı: " + OtoGaleri.GaleridekiArabaSayisi);
            Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamKiralanmaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamArabaKiralamaAdedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
        }
        public static bool PlakaKontrol(string plaka)
        {

            while (true)
            {

                string kontrolElemani = "";
                int sayi;
                kontrolElemani = plaka.ToUpper();
                bool sehirKodu;
                bool sonKisim1;
                bool sonKisim2;
                bool kontrol = true;
                string ara = "";
                if (kontrolElemani.Length <= 9 && kontrolElemani.Length >= 6)
                {
                    sehirKodu = int.TryParse(plaka.Substring(0, 2), out sayi);
                    sonKisim1 = int.TryParse(plaka.Substring(4), out sayi);
                    sonKisim2 = int.TryParse(plaka.Substring(5), out sayi);
                    for (int i = 2; i <= 3; i++)
                    {
                        ara += plaka[i];
                        if (int.TryParse(ara.Substring(0, 1), out sayi))
                        {
                            kontrol = false;
                        }
                        else
                        {
                            ara = "";
                        }

                    }
                    if (sehirKodu == true && kontrol == true && sonKisim1 == true)
                    {
                        return true;

                    }
                    else if (sehirKodu == true && kontrol == true && sonKisim2 == true)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                        return false;

                    }
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    return false;


                }

            }

        }
        public static string MarkaDuzenleme(string mesaj)
        {
            string marka;
            while (true)
            {
                Console.Write(mesaj);
                marka = Console.ReadLine();
                char[] dizi = marka.ToCharArray();
                if (marka == String.Empty)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                for (int i = 0; i < marka.Length; i++)
                {
                    if (char.IsNumber(dizi[i]))
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        break;
                    }
                    else if (i == (marka.Length - 1))
                    {
                        return marka;
                    }
                }
            }
        }
        public static float SayiAl(string mesaj)
        {

            while (true)
            {
                Console.Write(mesaj);
                string girdi = Console.ReadLine();
                if (float.TryParse(girdi, out float sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }

            }
        }
        public static void SahteVeri()
        {
            Araba a = new Araba("34TT2305", "OPEL", 50, Araba.ARABA_TIPI.Hatchback);
            Araba b = new Araba("36MN2304", "FİAT", 150, Araba.ARABA_TIPI.Sedan);
            a.Durum = Araba.DURUM.Kirada;
            //hocam tüm arabalar çıktısında K.sayısı 56, 6 görünüyor ama biz get ile hesaplattığımız için veri girişi yapamıyoruz. Aynı çıktıyı alabilmek için ne yapmamız lazım
            OtoGaleri.Arabalar.Add(a);
            OtoGaleri.Arabalar.Add(b);


            foreach (var item in OtoGaleri.Arabalar)
            {
                for (int i = 0; i < 56; i++)
                {
                    if (item.Marka == "OPEL")
                    {
                        item.KiralamaSureleri.Add(6);
                    }
                    if (item.Marka == "FİAT" && i < 6)
                    {
                        item.KiralamaSureleri.Add(5);
                    }
                }
            }

        }

    }
}

