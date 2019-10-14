using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {

        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public InstructieGroep()
        {
            MAX_LENGTE_RIJ = 5;
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {

            int verschil = args.VolgendeWachtrij.MAX_LENGTE_RIJ - args.VolgendeWachtrij.GetAlleSporters().Count;
            int aantal;

            if (verschil > GetAlleSporters().Count)
            {
                aantal = GetAlleSporters().Count;
            } else
            {
                aantal = verschil;
            }

            List<Sporter> sportersNaarWachtrijStarten = SportersVerlatenRij(aantal);



            InstructieAfgelopen.Invoke(new InstructieAfgelopenArgs() { sportersNaarVolgendeGroep = sportersNaarWachtrijStarten});

            int rest = MAX_LENGTE_RIJ - GetAlleSporters().Count;

            if (rest > args.VorigeWachtrij.GetAlleSporters().Count)
            {
                rest = args.VorigeWachtrij.GetAlleSporters().Count;
            }

            List<Sporter> sportersVanWachtrijInstructie = args.VorigeWachtrij.SportersVerlatenRij(rest);



            foreach(Sporter sporter in sportersVanWachtrijInstructie)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Dit is het instructie gedeelte van de wachtrij";
            return tekst;
        }
    }
}
