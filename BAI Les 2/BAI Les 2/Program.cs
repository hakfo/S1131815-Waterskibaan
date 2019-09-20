using System;

namespace BAI_Les_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int getallen = 5;
            int maxGetallen = 100;
            int[] array = new int[getallen];
            Random random = new Random();


            // Vul array met {getallen} getallen met een waarde van maximaal {maxGetallen}
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxGetallen);
            }

            int maxGetal = 0;
            int count = 0;
            int getal = 0;
            int minGetal = 100;
            int eenNaMinGetal = 100;

            // Print alle getallen in de array
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }


            // Controleer grootste en kleinste getal en een-na-laagste getal
            foreach (int i in array)
            {
                if (i < minGetal)
                {
                    eenNaMinGetal = minGetal;
                    minGetal = i;
                    count = 1;

                }
                else if (i == minGetal)
                {
                    count++;
                }
                else if (i > maxGetal)
                {
                    maxGetal = i;
                }
            }

            Console.WriteLine($"\nGrootste getal = {maxGetal}");
            Console.WriteLine($"Kleinste getal = {minGetal}");
            Console.WriteLine($"Kleinste getal komt {count} keer voor");
            Console.WriteLine($"Het een na kleinste getal is {eenNaMinGetal}");

            
            
        }
    }
}
