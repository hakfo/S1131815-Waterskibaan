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
            TestOpdracht2();
            Console.ReadLine();
            TestOpdracht3();
            Console.ReadLine();
            TestOpdracht5();
            Console.ReadLine();
        }

        static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();

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

            Console.WriteLine(kabel.ToString());
        }

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

        static void TestOpdracht5()
        {
            Sporter sporter = new Sporter(MoveCollection.GetWilleKeurigeMoves());
            Console.WriteLine(sporter.ToString());
        }
    }
}
