using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> sportersNaarVolgendeGroep { get; set; }
        public Wachtrij VolgendeWachtrij { get; set; }
        public Wachtrij VorigeWachtrij { get; set; }
    }
}
