using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RimworldLetterGravShipReady
{
    [StaticConstructorOnStartup]
    public class LGSMod : Mod
    {
        private readonly LGSSetting LGSSettings;
        public LGSMod(ModContentPack content)
            : base(content)
        {
            LGSSettings = base.GetSettings<LGSSetting>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("LGS_Option".Translate());
            listingStandard.CheckboxLabeled("LGS_Option_Enable".Translate(), ref LGSSettings.enable);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "LGS_Option_Mod_Name".Translate();
        }
    }
}
