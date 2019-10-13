using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
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


            int a = rand.Next(0, 255);
            int r = rand.Next(0, 255);
            int g = rand.Next(0, 255);
            int b = rand.Next(0, 255);

            sp.KledingKleur = Color.FromArgb(a, r, g, b);


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
