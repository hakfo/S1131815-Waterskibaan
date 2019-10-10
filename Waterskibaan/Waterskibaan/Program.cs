using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestOpdracht2();
            // Console.ReadLine();
            // TestOpdracht3();
            // Console.ReadLine();
            // TestOpdracht5();
            // Console.ReadLine();
            // TestOpdracht8();
            // Console.ReadLine();
            // TestOpdracht10();
            // Console.ReadLine();
            TestOpdracht11();
            Console.ReadLine();
        }

        // Test de kabel door er lijnen aan te hangen en deze rond te schuifen
        #region TestOpdrachten
        static void TestOpdracht2()
        {
/*            Kabel kabel = new Kabel();

            Lijn lijn = new Lijn(0);
            Lijn lijn2 = new Lijn(0);
            Lijn lijn3 = new Lijn(0);
            Lijn lijn4 = new Lijn(0);
            Lijn lijn5 = new Lijn(0);
            Lijn lijn6 = new Lijn(0);

            kabel.NeemLijnInGebruik(lijn);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn4);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn5);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn6);
            kabel.VerschuifLijnen();

            Console.WriteLine(kabel.ToString());*/
        }

        // Test de lijnenvoorraad door er lijnen aan toe te voegen en af te halen
        static void TestOpdracht3()
        {
            Lijn lijn7 = new Lijn(0);
            Lijn lijn8 = new Lijn(0);
            Lijn lijn9 = new Lijn(0);
            Lijn lijn10 = new Lijn(0);

            LijnenVoorraad lijnenvoorraad = new LijnenVoorraad();

            lijnenvoorraad.LijnToevoegenAanRij(lijn7);
            lijnenvoorraad.LijnToevoegenAanRij(lijn8);
            lijnenvoorraad.VerwijderEersteLijn();
            lijnenvoorraad.LijnToevoegenAanRij(lijn9);
            lijnenvoorraad.LijnToevoegenAanRij(lijn10);
            lijnenvoorraad.VerwijderEersteLijn();

            Console.WriteLine(lijnenvoorraad.ToString());
        }

        // Test de sporter z'n moves
        static void TestOpdracht5()
        {
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(5));
            Console.WriteLine(sporter.ToString());
        }

        // Test of de sporter z'n zwemvest en skies heeft
        static void TestOpdracht8()
        {
            Sporter sporter1 = new Sporter(MoveCollection.GetWillekeurigeMoves(5));
            Sporter sporter2 = new Sporter(MoveCollection.GetWillekeurigeMoves(5));
            Waterskibaan waterskibaan = new Waterskibaan(new LijnenVoorraad());

            sporter2.Zwemvest = new Zwemvest();
            sporter2.Skies = new Skies();

            waterskibaan.SporterStart(sporter1);
        }

        // Test de wachtrijen 
        // NOOT: Alle sporters die niet toegevoegd worden verdwijnen op het moment in het niks. Uitgaan van correcte invoer?
        static void TestOpdracht10()
        {
            WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
            InstructieGroep instructieGroep = new InstructieGroep();
            WachtrijStarten wachtrijStarten = new WachtrijStarten();
            

            for (int i = 0; i < 100; i++)
            {
                wachtrijInstructie.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves(5)));
            }

            Console.WriteLine(wachtrijInstructie.GetAlleSporters().Count);

            List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(5);

            foreach(Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }

            Console.WriteLine(instructieGroep.GetAlleSporters().Count);
        }
        #endregion
        static void TestOpdracht11()
        {
            Game game = new Game();

            game.Initialize();
        }
    }
}
