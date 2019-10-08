﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class SkiesNotEquippedException : Exception { }
    class ZwemvestNotEquippedException : Exception { }
    class Waterskibaan
    {

        private LijnenVoorraad lijnenVoorraad;
        private Kabel kabel = new Kabel();

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
            int randomRondjes = 1; //rand.Next(1, 3);
            sp.AantalRondenNogTeGaan = randomRondjes;
            sp.KledingKleur = (System.Drawing.Color.Blue);


            if (sp.Zwemvest == null)
            {
                throw new ZwemvestNotEquippedException();
            }

            if (sp.Skies == null)
            {
                throw new SkiesNotEquippedException();
            }
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
