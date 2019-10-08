using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    class Game
    {

        private static Timer timer;
        public Waterskibaan waterskibaan = new Waterskibaan(new LijnenVoorraad());
        static int counter = 0;
        Queue<Sporter> sporters = new Queue<Sporter>();

        public void Initialize()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            for(int i = 0; i < 15; i++)
            {
                sporters.Enqueue(new Sporter(MoveCollection.GetWilleKeurigeMoves()));
            }
        }

        void DequeueSporter()
        {
            if (sporters.Count > 0)
            {
                waterskibaan.SporterStart(sporters.Dequeue());
            } 
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            counter++;
            Console.WriteLine(counter + " seconde(s) voorbij");
            DequeueSporter();
            waterskibaan.VerplaatsKabel();
            Console.WriteLine(waterskibaan.ToString());
            
            if (waterskibaan.IsFinished())
            {
                Console.WriteLine("Alle sporters zijn van de baan af");
                timer.Stop();
            }
        }
    }
}
