using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{

    class Lijn
    {

        public int plek;

        public int PositieOpDeKabel
        {
            set
            {
                plek = value;
            }
            get
            {
                return plek;
            }
        }

        public Lijn(int positie)
        {
            PositieOpDeKabel = positie;
        }
    }

}
