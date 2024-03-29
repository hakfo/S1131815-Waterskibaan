﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijStarten : Wachtrij
    {

        public WachtrijStarten()
        {
            MAX_LENGTE_RIJ = 20;
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.sportersNaarVolgendeGroep) 
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Dit is wachtrij met mensen die klaar zijn met de instructie en klaar zijn om te starten";
            return tekst;
        }
    }
}
