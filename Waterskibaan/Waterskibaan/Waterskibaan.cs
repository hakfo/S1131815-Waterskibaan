using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {

        public LijnenVoorraad lijnenVoorraad;
        public Kabel kabel = new Kabel();
        public bool isGestart = false;

        public Waterskibaan(LijnenVoorraad lijnenVoorraad)
        {
            this.lijnenVoorraad = lijnenVoorraad;

            for (int i = 0; i < 15; i++)
            {
                Lijn lijn = new Lijn(0);
                lijnenVoorraad.LijnToevoegenAanRij(lijn);
            }

        }

        // Initialiseert de sporter en laat hem een paar rondjes gaan
        public void SporterStart(Sporter sp)
        {

            Console.WriteLine(sp + "" + sp.ID + " DIT IS EEN BIGGO TESTO");

            Lijn lijn = lijnenVoorraad.VerwijderEersteLijn();

            if (lijn != null)
            {
                sp.Lijn = lijn;
                lijn.sp = sp;
                kabel.NeemLijnInGebruik(lijn, lijnenVoorraad);
            }

            Random rand = new Random();
            int randomRondjes = rand.Next(1, 3);
            sp.AantalRondenNogTeGaan = randomRondjes;
            sp.KledingKleur = (System.Drawing.Color.Blue);


            if (sp.Zwemvest == null)
            {
                sp.Zwemvest = new Zwemvest();
            }

            if (sp.Skies == null)
            {
                sp.Skies = new Skies();
            }
        }

        public void Start()
        {
            isGestart = true;
        }

        public void Stop()
        {
            isGestart = false;
        }

        // Haalt de lijn van de kabel en voegt hem toe aan de lijnenvoorraad
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            lijnenVoorraad.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
        }

        public override string ToString()
        {
            string voorraadLijn = lijnenVoorraad.ToString();
            string overzichtKabel = kabel.ToString();
            string print = "";

            print += voorraadLijn;
            print += "\n";
            print += overzichtKabel;
            print += "\n";

            return print;
        }
    }
}
