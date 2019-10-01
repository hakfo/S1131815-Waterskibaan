using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {

        private LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
        private Kabel kabel = new Kabel();

        public Waterskibaan(LijnenVoorraad lijnenVoorraad)
        {
            for (int i = 0; i < 15; i++)
            {
                Lijn lijn = new Lijn(0);
                lijnenVoorraad.LijnToevoegenAanRij(lijn);
            }

        }

        public void SporterStart(Sporter sp)
        {
            kabel.NeemLijnInGebruik(sp.lijn);
            Random rand = new Random();
            int randomRondjes = rand.Next(1, 2);
            sp.AantalRondenNogTeGaan = randomRondjes;
            sp.KledingKleur = (System.Drawing.Color.Blue);
        }

        public void VerplaatsKabel()
        {
            lijnenVoorraad.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
        }

        public override string ToString()
        {
            string voorraadLijn = lijnenVoorraad.ToString();
            string overzichtKabel = kabel.ToString();
            string print = "";

            print += voorraadLijn;
            print += overzichtKabel;

            return print;
        }
    }
}
