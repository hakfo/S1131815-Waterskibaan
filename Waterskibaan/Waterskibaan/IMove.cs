using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    interface IMove
    {
        int MoeilijkheidsGraad { get; }
        int Score { get; }
        int Move();
    }
}
