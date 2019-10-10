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

            timer = new Timer(500);
            timer.Elapsed += OnTimedEvent;
            timer.Elapsed += OnLijnVerplaatst;
            timer.AutoReset = true;
            timer.Enabled = true;

            for (int i = 0; i < 20; i++)
            {
                sporters.Enqueue(new Sporter(MoveCollection.GetWillekeurigeMoves(5)));
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

                    if (lvCounter % 60 == 0)
                    {
                        Console.WriteLine("\n/*/*/*/*/\n");
                        foreach (Lijn lijn in waterskibaan.kabel._lijnen)
                        {
                            Console.WriteLine($"De sporter aan lijn {lijn.ID} heeft een huidige score van {lijn.sporter.BehaaldePunten}");
                        }
                        Console.WriteLine("\n/*/*/*/*/\n");
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    // TO DO:                                                                                         //
                    // ZORG DAT ALLE SPORTERS EEN KANS VAN 25% HEBBEN OM EEN MOVE TE DOEN.                            //
                    // VOLGENSMIJ DOEN ZE DAT AL, MAAR DE PRINT GEEFT ALLE ID'S EN DE MOVE VAN EEN ENKELING WEER.     //
                    // ZORGEN DAT ER ALLEEN GEPRINT WORDT ALS DIE SPECIFIEKE SPORTER OOK EEN MOVE ECHT HEEFT GEDAAN   //
                    //                                                                                                //
                    // PS: ER GEBEURT NOG NIKS MET DE PUNTEN, EN VOLGENSMIJ SLAGEN DE MOVES OP HET MOMENT OOK ALTIJD. //
                    // PLS FIX                                                                                        //
                    ////////////////////////////////////////////////////////////////////////////////////////////////////


                    

                    for (int i = 0; i < waterskibaan.kabel._lijnen.Count; i++)
                    {
                        Random rand = new Random();
                        int randomMovePercentage = rand.Next(0, 4);
                        if (randomMovePercentage > 1)
                        {
                            Lijn temp = waterskibaan.kabel._lijnen.ElementAt(i);
                            int randomMove = rand.Next(0, temp.sporter.Moves.Count());
                            int score = temp.sporter.Moves.ElementAt(randomMove).Move();
                            string naam = temp.sporter.Moves.ElementAt(randomMove).Naam;
                            temp.sporter.BehaaldePunten += score;

                            if(score != 0)
                            {
                                Console.WriteLine($"De sporter aan lijn {temp.ID} heeft een {naam} geprobeerd, dit heeft {score} punten opgeleverd. Zijn huidige totale score is {temp.sporter.BehaaldePunten}");
                            }
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
                nieuweBezoekerArgs.sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(5));
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
