using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class WachtrijStarten : Wachtrij
    {

        public WachtrijStarten()
        {
            MAX_LENGTE_RIJ = 20;
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Dit is wachtrij met mensen die klaar zijn met de instructie en klaar zijn om te starten";
            return tekst;
        }
    }
}
