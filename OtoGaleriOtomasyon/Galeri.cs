using System;
using System.Collections.Generic;

namespace OtoGaleriOtomasyon
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamArabaSayisi
        {

            get
            {

                return this.Arabalar.Count;

            }

        }

        public int KiradakiArabaSayisi
        {
            get
            {

                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == Araba.DURUM.Kirada)
                    {

                        adet++;

                    }
                }

                return adet;

            }
        }

        public int GaleridekiArabaSayisi
        {
            get
            {

                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == Araba.DURUM.Galeride)
                    {

                        adet++;

                    }
                }

                return adet;

            }
        }


        public int ToplamArabaKiralamaAdedi
        {
            get
            {

                int toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam+=item.KiralamaSureleri.Count;
                }

                return toplam;

            }
        }

        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam += item.ToplamKiralamaSuresi;
                }
                return toplam;

            }
        }

        public float Ciro 
        { 
            get 
            {
                float toplam = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplam += item.ArabaCirosu;
                }
                return toplam;
            } 
        }

        public void KiradakiArabalariListele()//33a1b12
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            if (this.Arabalar.Count == 0)
            {
                Console.WriteLine("Gösterilecek araba yok.");
                return;
            }
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12)
                 + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");

            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (Araba araba in this.Arabalar)
            {
                if (araba.Durum == Araba.DURUM.Kirada)
                {
                    Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(12)
                    + araba.KiralamaBedeli.ToString().PadRight(12) + araba.ArabaTipi.ToString().PadRight(12)
                    + araba.KiralamaSayisi.ToString().PadRight(12) + araba.Durum);
                }

            }

        }
        public void GaleridekiArabalariListele()
        {
            Console.WriteLine("-Galerideki Arabalar-");
            if (this.Arabalar.Count == 0)
            {
                Console.WriteLine("Gösterilecek araba yok.");
                return;
            }
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12)
                + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");

            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (Araba araba in this.Arabalar)
            {
                if (araba.Durum == Araba.DURUM.Galeride)
                {

                    Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(12)
                    + araba.KiralamaBedeli.ToString().PadRight(12) + araba.ArabaTipi.ToString().PadRight(12)
                    + araba.KiralamaSayisi.ToString().PadRight(12) + araba.Durum);
                }

            }
        }
        public void TumArabalariListele()
        {
            Console.WriteLine("-Tüm Arabalar-");
            if (this.Arabalar.Count == 0)
            {
                Console.WriteLine("Gösterilecek araba yok.");
                return;
            }
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12)
                + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");

            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (Araba araba in this.Arabalar)
            {
                Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(12)
                    + araba.KiralamaBedeli.ToString().PadRight(12) + araba.ArabaTipi.ToString().PadRight(12)
                    + araba.KiralamaSayisi.ToString().PadRight(12) + araba.Durum);
            }
        }

    }
}
