using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieGroep : Wachtrij
    {

        public InstructieGroep()
        {
            MAX_LENGTE_RIJ = 5;
        }

        public void InstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            for (int i = 0; i < MAX_LENGTE_RIJ; i++)
            {
                SporterNeemPlaatsInRij(args.sportersNaarInstructieGroep.First());
            }
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Dit is het instructie gedeelte van de wachtrij";
            return tekst;
        }
    }
}
