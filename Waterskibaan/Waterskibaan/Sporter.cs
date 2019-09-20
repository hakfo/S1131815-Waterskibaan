using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Sporter
    {

        public int AantalRondenNogTeGaan = 0;
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;
        public int BehaaldePunten;
        public List<IMoves> Moves;

        public Sporter(List<IMoves> moves)
        {

        }


    }
}
