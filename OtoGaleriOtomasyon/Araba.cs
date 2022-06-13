using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriOtomasyon
{
    class Araba
    {
        public  string Plaka;
        public string Marka;

        public float KiralamaBedeli;

        public List<int> KiralamaSureleri = new List<int>() {};//sahte veri girişleri//6,6,6,6,6,6,6,6,6,6 56
       
        public DURUM Durum;
        public ARABA_TIPI ArabaTipi;
        
        public float ArabaCirosu
        {

            get
            {
                return this.ToplamKiralamaSuresi * this.KiralamaBedeli;
               

            }

        }
        public int KiralamaSayisi
        {

            get
            {

                return this.KiralamaSureleri.Count;

            }

        }

        public int ToplamKiralamaSuresi
        {
            get
            {
                int saatToplam = 0;
                foreach (int item in this.KiralamaSureleri)
                {
                    saatToplam += item;
                }
                return saatToplam;

            }
        }


        public Araba(string plaka, string marka, float kiralamaBedeli, ARABA_TIPI arabaTipi)
        {

            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.ArabaTipi = arabaTipi;
            this.KiralamaBedeli = kiralamaBedeli;
            
            this.Durum = DURUM.Galeride;

        }



        public enum DURUM
        {
            Galeride,
            Kirada,
            Default
        }


        public enum ARABA_TIPI
        {
            SUV,
            Hatchback,
            Sedan,
            Default
        }

    }
}
