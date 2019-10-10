using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        // Bepaal of een lijn aangekoppeld kan worden
        public bool IsStartPositieLeeg()
        {
            if ((_lijnen.First == null) || (_lijnen.First.Value.PositieOpDeKabel != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Voeg een lijn toe op positie 0
        public void NeemLijnInGebruik(Lijn lijn, LijnenVoorraad voorraad)
        {

            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
            }
            else
            {
                Console.WriteLine("Lijn is niet leeg");
                voorraad.LijnToevoegenAanRij(lijn);
            }
        }
    
        // Verhoog de positie van alle lijnen met 1
        public void VerschuifLijnen()
        {
            #region
            // Eerste poging gebruik gemaakt van nodes, niet nodig. Bewaren als voorbeeld.

            /*            Console.WriteLine("VerschuifLijnen");

                          LinkedListNode<Lijn> huidigeNode = _lijnen.First;

                          for(int i = _lijnen.Count; i > 0; i--)
                          {
                          huidigeNode.Value.PositieOpDeKabel++;
                          huidigeNode = huidigeNode.Next;
                          }
            */
            #endregion


            for (int i = 0; i < _lijnen.Count; i++)
            {
                Lijn last = _lijnen.Last.Value;

                try
                {
                    if (last.PositieOpDeKabel == 9)
                    {
                        last.PositieOpDeKabel = 0;
                        _lijnen.RemoveLast();
                        _lijnen.AddFirst(last);
                        _lijnen.Last.Value.sporter.AantalRondenNogTeGaan--;
                    }
                    else
                    {
                        _lijnen.ElementAt(i).PositieOpDeKabel++;
                        //Console.WriteLine(_lijnen.ElementAt(i));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // 'Verwijder' de laatste lijn van de kabel.
        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Last.Value.PositieOpDeKabel == 9 && _lijnen.Last.Value.sporter.AantalRondenNogTeGaan <= 1)
            {
                Lijn lijn = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                lijn.PositieOpDeKabel = 0;
                return lijn;
            }
            else
            {
                return null;
            }

        }

        public bool Empty()
        {
            return _lijnen.Count == 0;
        }

        // ToString om de positie van de lijnen op de kabel te zien

        public override string ToString()
        {

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
