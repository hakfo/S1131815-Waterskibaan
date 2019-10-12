using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {

        public WachtrijInstructie()
        {
            MAX_LENGTE_RIJ = 100;
        }

        public void NieuweBezoeker(NieuweBezoekerArgs args)
        {
            SporterNeemPlaatsInRij(args.sporter);
        }
       
        public override string ToString()
        {
            string tekst = "";
            tekst += "Dit is de rij die afwacht tot ze instructie krijgen";
            return tekst;
        }
    }
}
