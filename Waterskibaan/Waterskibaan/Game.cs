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
        static int oteCounter = 0;
        static int lvCounter = 0;
        Queue<Sporter> sporters = new Queue<Sporter>();

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;
        public WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();

        public void NieuweBezoekers(NieuweBezoekerArgs args)
        {
            NieuweBezoeker?.Invoke(args);
        }

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public InstructieGroep instructieGroep = new InstructieGroep();

        public void BezoekersNaarInstructie(InstructieAfgelopenArgs args)
        {
            InstructieAfgelopen?.Invoke(args);
        }

        public WachtrijStarten wachtrijStarten = new WachtrijStarten();

        public void Initialize()
        {
            NieuweBezoeker += wachtrijInstructie.NieuweBezoeker;
            InstructieAfgelopen += instructieGroep.InstructieAfgelopen;

            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Elapsed += OnLijnVerplaatst;
            timer.AutoReset = true;
            timer.Enabled = true;

            for (int i = 0; i < 20; i++)
            {
                sporters.Enqueue(new Sporter(MoveCollection.GetWilleKeurigeMoves()));
            }
        }

        public event EventHandler LijnVerplaatst;

        public void OnLijnVerplaatst(Object source, ElapsedEventArgs e)
        {

            lvCounter++;
            EventHandler handler = LijnVerplaatst;
            LijnVerplaatst?.Invoke(this, e);

            if (waterskibaan.isGestart == true)
            {
                if (waterskibaan.kabel.IsStartPositieLeeg())
                {
                    List<Sporter> tempSporterList = wachtrijStarten.SportersVerlatenRij(1);

                    foreach (Sporter tempSporter in tempSporterList)
                    {
                        waterskibaan.SporterStart(tempSporter);
                        Console.WriteLine("Er is een sporter gestart");
                    }
                }
                if (lvCounter % 4 == 0)
                {
                    waterskibaan.VerplaatsKabel();

                    Random rand = new Random();
                    int randomMovePercentage = rand.Next(0, 4);
                    foreach (Lijn lijn in waterskibaan.kabel._lijnen)
                    {
                        if (randomMovePercentage > 1)
                        {
                            Random randMove = new Random();
                            int randomMove = randMove.Next(0, lijn.sp.Moves.Count);
                            

                            ////////////////////////////////////////////////////////////////////////////////////////////////////
                            // TO DO:                                                                                         //
                            // ZORG DAT ALLE SPORTERS EEN KANS VAN 25% HEBBEN OM EEN MOVE TE DOEN.                            //
                            // VOLGENSMIJ DOEN ZE DAT AL, MAAR DE PRINT GEEFT ALLE ID'S EN DE MOVE VAN EEN ENKELING WEER.     //
                            // ZORGEN DAT ER ALLEEN GEPRINT WORDT ALS DIE SPECIFIEKE SPORTER OOK EEN MOVE ECHT HEEFT GEDAAN   //
                            //                                                                                                //
                            // PS: ER GEBEURT NOG NIKS MET DE PUNTEN, EN VOLGENSMIJ SLAGEN DE MOVES OP HET MOMENT OOK ALTIJD. //
                            // PLS FIX                                                                                        //
                            ////////////////////////////////////////////////////////////////////////////////////////////////////
                            

                            lijn.sp.HuidigeMove = lijn.sp.Moves.ElementAt(randomMove);
                            Console.WriteLine($"De sporter op lijn {lijn.ID} heeft een {lijn.sp.HuidigeMove} gedaan!");

                        }
                    }
                }
            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            oteCounter++;
            Console.WriteLine(oteCounter + " seconde(s) voorbij");

            if (wachtrijStarten.GetAlleSporters().Count >= 10)
            {
                waterskibaan.Start();
            }

            if (oteCounter % 3 == 0)
            {
                NieuweBezoekerArgs nieuweBezoekerArgs = new NieuweBezoekerArgs();
                nieuweBezoekerArgs.sporter = new Sporter(MoveCollection.GetWilleKeurigeMoves());
                NieuweBezoekers(nieuweBezoekerArgs);
                Console.WriteLine("\n" + wachtrijInstructie.GetAlleSporters().Count + " bezoeker(s) in de WachtrijInstructie\n");
            }

            if (oteCounter % 20 == 0)
            {
                InstructieAfgelopenArgs instructieAfgelopenArgs = new InstructieAfgelopenArgs();
                instructieAfgelopenArgs.sportersNaarInstructieGroep = wachtrijInstructie.SportersVerlatenRij(5);
                BezoekersNaarInstructie(instructieAfgelopenArgs);
                Console.WriteLine("\n" + wachtrijInstructie.GetAlleSporters().Count + " bezoeker(s) in de WachtrijInstructie");
                Console.WriteLine(instructieGroep.GetAlleSporters().Count + " bezoeker(s) in de InstructieGroep\n");

                List<Sporter> tempSporters = instructieGroep.SportersVerlatenRij(5);

                if (wachtrijStarten.GetAlleSporters().Count <= wachtrijStarten.MAX_LENGTE_RIJ)
                {
                    foreach (Sporter tempSporter in tempSporters)
                    {
                        wachtrijStarten.SporterNeemPlaatsInRij(tempSporter);
                    }
                }
                else
                {
                    Console.WriteLine("WachtrijStarten is vol!");
                }

                Console.WriteLine(instructieGroep.GetAlleSporters().Count + " bezoeker(s) in de InstructieGroep");
                Console.WriteLine(wachtrijStarten.GetAlleSporters().Count + " bezoeker(s) in de WachtrijStarten\n");
            }
        }
    }
}
