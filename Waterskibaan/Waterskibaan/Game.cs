using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{

    public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
    public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);

    public class Game
    {
        private static Timer timer;
        public Waterskibaan waterskibaan = new Waterskibaan(new LijnenVoorraad());
        public int oteCounter = 0;
        public static int lvCounter = 0;
        Queue<Sporter> sporters = new Queue<Sporter>();

        // NieuweBezoeker event, bezoeker wordt aangemaakt en gaat wachtrijInstructie in
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        public void NieuweBezoekers(NieuweBezoekerArgs args)
        {
            NieuweBezoeker?.Invoke(args);
        }

        //BezoekersNaarInstructie event, bezoeker gaat van wachtrijInstructie naar instructieGroep
 
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public InstructieGroep instructieGroep = new InstructieGroep();
        public void BezoekersNaarInstructie(InstructieAfgelopenArgs args)
        {
            InstructieAfgelopen?.Invoke(args);
        }

        // Hoort niet bij het bovenstaande blok, maar heeft te maken met het event dat er voor zorgt dat SporterStart aangeroepen wordt.
        public WachtrijStarten wachtrijStarten = new WachtrijStarten();

        // Initialiseert de Timer en zorgt dat de events aangeroepen kunnen worden.
        public void Initialize()
        {
            NieuweBezoeker += wachtrijInstructie.NieuweBezoeker;
            InstructieAfgelopen += instructieGroep.OnInstructieAfgelopen;
            instructieGroep.InstructieAfgelopen += wachtrijStarten.OnInstructieAfgelopen;

            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Elapsed += OnLijnVerplaatst;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        // LijnVerplaatst event, zorgt ervoor dat de sporters in wachtrijStarten toegevoegd worden aan de waterskibaan doormiddel van SporterStart
        public event EventHandler LijnVerplaatst;

        // Vangt de events op ddie LijnVerplaatst willen
        public void OnLijnVerplaatst(Object source, ElapsedEventArgs e)
        {

            lvCounter++;
            EventHandler handler = LijnVerplaatst;
            LijnVerplaatst?.Invoke(this, e);

            // Als waterskibaan.Start() gerunt is; (Wordt in de WPF gedaan door de startknop)
            if (waterskibaan.isGestart == true)
            {
                if (waterskibaan.kabel.IsStartPositieLeeg())
                {
                    // Een heel lelijk stuk code die een enkele sporter uit de lijst haalt zodat deze kan starten.
                    Sporter tempSporter = wachtrijStarten.SportersVerlatenRij(1)[0];

                     waterskibaan.SporterStart(tempSporter);
                     Console.WriteLine("Er is een sporter gestart");
                }
                // Om de 4 seconden
                if (lvCounter % 4 == 0)
                {
                    waterskibaan.VerplaatsKabel();

                    // Om de 60 seconden
                    if (lvCounter % 60 == 0)
                    {
                        // Print een klein overzicht van alle huidige sporters met hun ID en hun punten

                        Console.WriteLine("\n/*/*/*/*/\n");
                        foreach (Lijn lijn in waterskibaan.kabel._lijnen)
                        {
                            Console.WriteLine($"De sporter aan lijn {lijn.ID} heeft een huidige score van {lijn.sp.BehaaldePunten}");
                        }
                        Console.WriteLine("\n/*/*/*/*/\n");
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    // TO DO:                                                                                         //
                    // ZORG DAT ALLE SPORTERS EEN KANS VAN 25% HEBBEN OM EEN MOVE TE DOEN.                            //
                    // VOLGENSMIJ DOEN ZE DAT AL, MAAR DE PRINT GEEFT ALLE ID'S EN DE MOVE VAN EEN ENKELING WEER.     //
                    // ZORGEN DAT ER ALLEEN GEPRINT WORDT ALS DIE SPECIFIEKE SPORTER OOK EEN MOVE ECHT HEEFT GEDAAN   //
                    //                                                                                                //
                    // PS: PUNTEN ZIJN ZEER KAPOT                                                                     //
                    // PLS FIX                                                                                        //
                    ////////////////////////////////////////////////////////////////////////////////////////////////////

                    // Voor hoeveel lijnen momenteel op de kabel zijn (oftewel spelers)
                    for (int i = 0; i < waterskibaan.kabel._lijnen.Count; i++)
                    {
                        // Berekent een 25% kans voor een sporter om een move te doen
                        Random rand = new Random(DateTime.Now.Millisecond);
                        int randomMovePercentage = rand.Next(0, 4);
                        Lijn temp = waterskibaan.kabel._lijnen.ElementAt(i);
                        if (randomMovePercentage > 1)
                        {
                            // Kiest een move in de lijst van moves die een sporter heeft
                            int randomMove = rand.Next(0, temp.sp.Moves.Count());

                            // Voert de move uit en returned de opgegeven score (Succeskans wordt in de move al berekend, dus returned 0 als het faalt)
                            int score = temp.sp.Moves.ElementAt(randomMove).Move();

                            // Haalt de naam van de move op
                            string naam = temp.sp.Moves.ElementAt(randomMove).Naam;

                            // Verandert de HuidigeMove naar de... huidige... move?
                            temp.sp.HuidigeMove = temp.sp.Moves.ElementAt(randomMove);

                            // Voegt de behaalde score van de move bij de totaal behaalde punten van de sporter
                            temp.sp.BehaaldePunten += score;

                            Console.WriteLine($"De sporter {temp.sp.ID} aan lijn {temp.ID} heeft een {naam} geprobeerd, dit heeft {score} punten opgeleverd. Zijn huidige totale score is {temp.sp.BehaaldePunten}");
                        }
                        else
                        {
                            temp.sp.HuidigeMove = null;
                        }
                    }
                }
            }
        }

        // Vangt de events op die om de seconde gebeuren
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Houdt de hoeveelheid secondes bij dat het programma al loopt
            oteCounter++;
            Console.WriteLine(oteCounter + " seconde(s) voorbij");

            // Om de 3 seconden
            if (oteCounter % 3 == 0)
            {
                NieuweBezoekerArgs nieuweBezoekerArgs = new NieuweBezoekerArgs();
                nieuweBezoekerArgs.sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(5));
                NieuweBezoekers(nieuweBezoekerArgs);
            }

            // Om de 20 seconden
            if (oteCounter % 20 == 0)
            {
                InstructieAfgelopenArgs instructieAfgelopenArgs = new InstructieAfgelopenArgs();
                instructieAfgelopenArgs.VorigeWachtrij = wachtrijInstructie;
                instructieAfgelopenArgs.VolgendeWachtrij = wachtrijStarten;



                InstructieAfgelopen.Invoke(instructieAfgelopenArgs);



            }
            Console.WriteLine("\n" + wachtrijInstructie.GetAlleSporters().Count + " bezoeker(s) in de WachtrijInstructie");
            Console.WriteLine(instructieGroep.GetAlleSporters().Count + " bezoeker(s) in de InstructieGroep");
            Console.WriteLine(wachtrijStarten.GetAlleSporters().Count + " bezoeker(s) in de WachtrijStarten\n");
        }
    }
}
