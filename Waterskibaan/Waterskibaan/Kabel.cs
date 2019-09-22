using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        // Bepaal of een lijn aangekoppeld kan worden
        public bool IsStartPositieLeeg()
        {
            Console.WriteLine("IsStartPositieLeeg");
            if (_lijnen.First == null || _lijnen.First.Value.PositieOpDeKabel != 0)
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
            Console.WriteLine("NeemLijnInGebruik");

            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
            }
        }

        // Verhoog de positie van alle lijnen met 1
        public void VerschuifLijnen()
        {
            Console.WriteLine("VerschuifLijnen");

            LinkedListNode<Lijn> huidigeNode = _lijnen.First;

            for(int i = _lijnen.Count; i > 0; i--)
            {
                huidigeNode.Value.PositieOpDeKabel++;
                huidigeNode = huidigeNode.Next;
            }
        }

        // 'Verwijder' de laatste lijn van de kabel.
        public Lijn VerwijderLijnVanKabel()
        {
            Console.WriteLine("VerwijderLijnVanKabel");

            if (_lijnen.Last.Value.PositieOpDeKabel == 9)
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
            Console.WriteLine("ToString");

            LinkedListNode<Lijn> huidigeNode = _lijnen.First;
            string printLijst = "";

            for(int i = _lijnen.Count; i > 0; i--)
            {
                printLijst += huidigeNode.Value.PositieOpDeKabel;
                if(huidigeNode.Next != null)
                {
                    printLijst += " | ";
                }
                huidigeNode = huidigeNode.Next;
            }
            return printLijst;
        }


    }

}
