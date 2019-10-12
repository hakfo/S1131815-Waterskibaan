using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public interface IMove
    {
        int MoeilijkheidsGraad { get; set; }
        int Score { get; set; }
        string Naam { get; set; }
        int Move();
    }
}
