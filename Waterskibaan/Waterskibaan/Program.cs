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
            Lijn lijn = new Lijn();
            Lijn lijn2 = new Lijn();

            kabel.NeemLijnInGebruik(lijn);
            kabel.NeemLijnInGebruik(lijn2);

            Console.WriteLine(kabel.ToString());
        }
    }
}
