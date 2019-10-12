using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{

    public class Lijn
    {

        static int counter = 0;
        public int ID;

        private int plek;
        public Sporter sp;

        public int PositieOpDeKabel
        {
            get
            {
                return plek;
            }
            set
            {
                plek = value;
            }
        }

        public Lijn(int positie)
        {
            ID = counter;
            PositieOpDeKabel = positie;
            counter++;
        }

        public override string ToString()
        {
            return $"[Lijn nummer = [{ID}][PositieOpDeKabel = [{PositieOpDeKabel}]]";
        }
    }

}
