using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{

    class Lijn
    {

        private int plek;

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
            PositieOpDeKabel = positie;
        }
    }

}
