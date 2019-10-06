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

        // Haalt een lijst met alle sporters in de rij op
        public List<Sporter> GetAlleSporters()
        {
            Console.WriteLine("GetAlleSporters");

            if (sporters.Count == 0)
            {
                Console.WriteLine("Er staan geen sporters in de wachtrij");
            }

            return sporters.ToList();
        }

        // Voegt de geleverde sporter in de bijbehorende queue
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

        // Maakt een nieuwe lijst met de (aantal) sporters die gereturned wordt. (Om bijvoorbeeld over te zetten naar de volgende queue)
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
