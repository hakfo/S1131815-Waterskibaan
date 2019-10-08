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

        public int AantalRondenNogTeGaan = 0;
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;
        public int BehaaldePunten;
        public List<IMove> Moves;
        public Lijn Lijn { get; set; }

        public Sporter(List<IMove> moves)
        {
            this.Moves = moves;
            this.Zwemvest = new Zwemvest();
            this.Skies = new Skies();
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
