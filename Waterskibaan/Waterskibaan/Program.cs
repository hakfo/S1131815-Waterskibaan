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
        }

        static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();

            Lijn lijn = new Lijn(0);
            Lijn lijn2 = new Lijn(0);
            Lijn lijn3 = new Lijn(0);
            Lijn lijn4 = new Lijn(0);

            kabel.NeemLijnInGebruik(lijn);
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn4);

            Console.WriteLine(kabel.ToString());
        }
    }
}
