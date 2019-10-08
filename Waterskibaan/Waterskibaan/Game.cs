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

        public void Initialize()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            counter++;
            Console.WriteLine(counter + " keer gerunt");
            waterskibaan.SporterStart(new Sporter(MoveCollection.GetWilleKeurigeMoves()));
            waterskibaan.VerplaatsKabel();
            Console.WriteLine(waterskibaan.ToString());

        }
    }
}
