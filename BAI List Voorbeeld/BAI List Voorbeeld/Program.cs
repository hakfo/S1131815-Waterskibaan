using System;
using System.Collections.Generic;

namespace BAI_List_Voorbeeld
{
    class Program
    {
        static void Main(string[] args)
        {
            /*          
            List<int> lijst = new List<int>();

            for (int i = 10000; i <= 1000000; i++)
            {
                lijst.Add(i);
            }

            double som = 0;

            foreach (int num in lijst)
            {
                som += num;
            }

            Console.Write(som);
            
            */

            Console.Write("Voer een x in\n");
            int x = 100;
            int y = 0;
            int aantal = 0;
            List<int> getallen = new List<int>();
            
            while(x != 0)
            {
                x = Convert.ToInt32(Console.ReadLine());
                if(x > 0)
                {
                    for(y = 0; y < x; y++) {
                        getallen.Add(x);
                        aantal++;
                    }
                    
                }
                if(x < 0)
                {
                    for(y = 0; y < x*-1; y++)
                    {
                        int count = getallen.Count - 1;
                        getallen.RemoveAt(count);
                        aantal--;
                    }
                }
            }

            foreach(int i in getallen)
            {
                Console.Write($" {i} ");
            }

            Console.WriteLine($"\nEr zijn {aantal} nummers");
            Console.WriteLine($"Het laatste nummer is {getallen[getallen.Count-1]}");
        }
    }
}
