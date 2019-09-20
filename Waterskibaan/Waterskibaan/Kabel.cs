using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        // Bepaal of een lijn aangekoppeld kan worden
        public bool IsStartPositieLeeg()
        {
            if (_lijnen.First == null || _lijnen.Count == 0)
            {
                return true;
            } else {
                return false;
            }
        }

        // Voeg een lijn toe op positie 0
        public void NeemLijnInGebruik(Lijn lijn)
        {
             if(IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
            }
        }

        // Verhoog de positie van alle lijnen met 1
        public void VerschuifLijnen()
        {
            foreach(Lijn lijn in _lijnen)
            {
                // verhoog de positie van alle lijnen in _lijnen met 1 t/m 9. 9 moet terugcirkelen naar 0.
            }

        }

        // 'Verwijder' de laatste lijn van de kabel.
        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Last != null)
            {
                return _lijnen.Last.Value;
            } else
            {
                return null;
            }
        }

        // ToString om de positie van de lijnen op de kabel te zien
        public string overload ToString()
        {
            foreach(Lijn lijn in _lijnen)
            {
                // Kan geen lijn.Value gebruiken?
            }
        }


    }

}
