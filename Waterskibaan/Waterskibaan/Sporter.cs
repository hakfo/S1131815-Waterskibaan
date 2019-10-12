using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter
    {
        static int counter = 0;
        public int ID;
        public int AantalRondenNogTeGaan = 0;
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;
        public int BehaaldePunten { get; set; }
        public List<IMove> Moves;
        public Lijn Lijn { get; set; }
        public IMove HuidigeMove { get; set; }
        int punten;
        public Sporter(List<IMove> moves)
        {
            BehaaldePunten = 0;
            foreach(IMove move in moves)
            {
                punten = move.Score;
                BehaaldePunten = punten;
            }
            this.Moves = moves;
            this.Zwemvest = new Zwemvest();
            this.Skies = new Skies();

            ID = counter;
            counter++;
        }

        public override string ToString()
        {
            string tekst = "";
            foreach(IMove move in Moves)
            {
                tekst += move;
                tekst += $"\tScore is {move.Score}";
                tekst += $"\tMoeilijkheidsgraad van deze move is {move.MoeilijkheidsGraad}";
                tekst += "\n";
            }
            return tekst;
        }
    }
}
