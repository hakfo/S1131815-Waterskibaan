using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    static class MoveCollection
    {
        static List<IMove> moves = new List<IMove>();

        // Voegt willekeurige moves toe aan een lijst die meegegeven wordt aan een sporter
        public static List<IMove> GetWilleKeurigeMoves()
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            int grootte = rand1.Next(1, 11);

            for (int i = 0; i < grootte; i++)
            {

                int move = rand2.Next(1, 5);

                if (move == 1)
                {
                    moves.Add(new Jump());
                } else if (move == 2)
                {
                    moves.Add(new Omdraaien());
                } else if (move == 3)
                {
                    moves.Add(new EenBeen());
                } else if (move == 4)
                {
                    moves.Add(new EenArm());
                }
            }
            return moves;
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class Jump : IMove
    {
        public int MoeilijkheidsGraad { get { return 50; } }
        public int Score { get { return 30; } }
        public int Move()
        {
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            return Score;
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class Omdraaien : IMove
    {
        public int MoeilijkheidsGraad { get { return 80; } }
        public int Score { get { return 60; } }
        public int Move()
        {
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            return Score;
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class EenBeen : IMove
    {
        public int MoeilijkheidsGraad { get { return 30; } }
        public int Score { get { return 20; } }
        public int Move()
        {
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            return Score;
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class EenArm : IMove
    {
        public int MoeilijkheidsGraad { get { return 20; } }
        public int Score { get { return 10; } }
        public int Move()
        {
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            return Score;
        }
    }
}
