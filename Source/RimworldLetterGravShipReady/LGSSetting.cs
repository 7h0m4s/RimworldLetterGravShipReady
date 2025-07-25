using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldLetterGravShipReady
{
    internal class LGSSetting : ModSettings
    {
        public bool enable = true;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref enable, "enable", true, false);
            base.ExposeData();
        }
    }
}
