using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel : Lijn
    {
        private static LinkedList<Lijn> _lijnen;

        // Bepaal of een lijn aangekoppeld kan worden
        public bool IsStartPositieLeeg()
        {
            if (_lijnen.First == null || _lijnen.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Voeg een lijn toe op positie 0
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
            }
        }

        // Verhoog de positie van alle lijnen met 1
        public void VerschuifLijnen()
        {
            // Zou een nullwaarde aan de voorkant van de list moeten toevoegen om zo alles 1 plek naar voren te schuiven
            _lijnen.AddFirst(value: null);

            // Controleer of de laatste node de 9e positie gepasseerd is en verplaats deze naar positie 0
        }

        // 'Verwijder' de laatste lijn van de kabel.
        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Last != null)
            {
                return _lijnen.Last.Value;
            }
            else
            {
                return null;
            }
        }

        // ToString om de positie van de lijnen op de kabel te zien

        public override string ToString()
        {
            return null;
        }


    }

}
