using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Wachtrij : IWachtrij
    {

        Queue<Sporter> sporters = new Queue<Sporter>();
        public int MAX_LENGTE_RIJ;

        public List<Sporter> GetAlleSporters()
        {
            Console.WriteLine("GetAlleSporters");

            if (sporters.Count == 0)
            {
                Console.WriteLine("Er staan geen sporters in de wachtrij");
            }

            return sporters.ToList();
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            Console.WriteLine("SporterNeemPlaatsInRij");

            if (sporters.Count() < MAX_LENGTE_RIJ)
            {
                sporters.Enqueue(sporter);
            }
            else
            {
                Console.WriteLine("De wachtrij is vol");
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {

            Console.WriteLine("SportersVerlatenRij");

            List<Sporter> sporterLijst = new List<Sporter>();

            for (int i = 0; i < aantal; i++)
            {
                if (sporters.Count > 0)
                {
                    sporterLijst.Add(sporters.Dequeue());
                }
                else
                {
                    return sporterLijst;
                }
            }

            return sporterLijst;
        }
    }
}
