using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class LijnenVoorraad
    {

        public Queue<Lijn> _lijnen = new Queue<Lijn>();

        // Voeg een gegeven lijn toe aan de rij
        public void LijnToevoegenAanRij(Lijn lijn)
        {
            if (lijn != null)
            {
                _lijnen.Enqueue(lijn);
            }
        }

        // 'Verwijder' eerste lijn
        public Lijn VerwijderEersteLijn()
        {
            if(_lijnen.Count == 0)
            {
                return null;
            }
            else
            {
                Lijn lijn = _lijnen.Peek();
                _lijnen.Dequeue();
                return lijn;
            }
        }

        // Haalt hoeveelheid lijnen op
        public int GetAantalLijnen()
        {
            return _lijnen.Count();
        }

        // ToString om de hoeveelheid lijnen in voorraad te printen
        public override string ToString()
        {
            string printLijst = "";
            printLijst += GetAantalLijnen();
            printLijst += " lijnen op voorraad";
            return printLijst;
        }
    }
}
