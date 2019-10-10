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
        public static List<IMove> GetWillekeurigeMoves(int num)
        {
            List<IMove> Moves = new List<IMove>();
            Moves.Add(new Jump());
            Moves.Add(new EenArm());
            Moves.Add(new EenBeen());
            Moves.Add(new Omdraaien());

            Random rand = new Random();
            List<IMove> selectedMoves = new List<IMove>();

            for (int i = 0; i < num; i++)
            {
                var index = rand.Next(Moves.Count());
                selectedMoves.Add(Moves[index]);
                //Console.WriteLine(Moves[rand.Next(Moves.Count)]);
            }

            return selectedMoves;
        }
    }


    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class Jump : IMove
    {
        public int MoeilijkheidsGraad { get; set; }
        public int Score { get; set; }
        public string Naam { get; set; }
        public int Move()
        {
            Naam = "Jump";
            MoeilijkheidsGraad = 50;
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (51 < MoeilijkheidsGraad)
            {
                return 0;
            }
            else
            {
                return Score = 30;
            }
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class Omdraaien : IMove
    {
        public int MoeilijkheidsGraad { get; set; }
        public int Score { get; set; }
        public string Naam { get; set; }
        public int Move()
        {
            Naam = "Omdraaien";
            MoeilijkheidsGraad = 80;
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            else
            {
                return Score = 60;
            }
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class EenBeen : IMove
    {
        public int MoeilijkheidsGraad { get; set; }
        public int Score { get; set; }
        public string Naam { get; set; }
        public int Move()
        {
            Naam = "EenBeen";
            MoeilijkheidsGraad = 30;
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            }
            else
            {
                return Score = 20;
            }
        }
    }

    // Bepaalt de move, de moeilijkheidsgraad, de score en de parameters die bepalen of deze move slaagt of niet
    public class EenArm : IMove
    {
        public int MoeilijkheidsGraad { get; set; }
        public int Score { get; set; }
        public string Naam { get; set; }
        public int Move()
        {
            Naam = "EenArm";
            MoeilijkheidsGraad = 20;
            Random rand = new Random();
            int randomNummer = rand.Next(0, 101);
            if (randomNummer < MoeilijkheidsGraad)
            {
                return 0;
            } else
            {
                return Score = 10;
            }
        }
    }
}
