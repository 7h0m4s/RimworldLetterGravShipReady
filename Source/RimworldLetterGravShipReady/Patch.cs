using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldLetterGravShipReady
{
    [HarmonyPatch(typeof(Building_GravEngine), "Tick")]
    public class Patch
    {
        public static void Postfix(Building_GravEngine __instance)
        {
            // Access the cooldownCompleteTick field of the gravEngine instance
            int cooldownTick = Traverse.Create(__instance).Field("cooldownCompleteTick").GetValue<int>();

            if (Find.TickManager.TicksGame == cooldownTick)
            {
                bool enable = ((Mod)LoadedModManager.GetMod<LGSMod>()).GetSettings<LGSSetting>().enable;
                if (enable)
                {
                    TaggedString label = "LGS_Letter_Label".Translate();
                    TaggedString text = "LGS_Letter_Text".Translate();
                    LookTargets targets = new LookTargets(__instance);
                    ChoiceLetter letter = LetterMaker.MakeLetter(label, text, LetterDefOf.NeutralEvent, targets, null, null, null);
                    Find.LetterStack.ReceiveLetter(letter);
                }
            }
        }
    }
}
