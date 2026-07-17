using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldLetterGravShipReady
{
    [HarmonyPatch(typeof(Building_GravEngine), "Tick")]
    public class Patch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var newInstructionList = new List<CodeInstruction>();
            foreach (var code in instructions)
            {
                newInstructionList.Add(code);
                if (code.opcode == OpCodes.Call && code.operand.ToString().Contains("Void Message("))
                {
                    newInstructionList.Add(new CodeInstruction(OpCodes.Ldarg_0));
                    newInstructionList.Add(CodeInstruction.Call(typeof(Patch), nameof(SpawnGravLetter), new []{typeof(Building_GravEngine)}));
                }
            }
            
            return newInstructionList;
        }

        public static void SpawnGravLetter(Building_GravEngine instance)
        {
            bool enable = ((Mod)LoadedModManager.GetMod<LGSMod>()).GetSettings<LGSSetting>().enable;
            if (enable)
            {
                TaggedString label = "LGS_Letter_Label".Translate();
                TaggedString text = "LGS_Letter_Text".Translate();
                LookTargets targets = new LookTargets(instance);
                ChoiceLetter letter =
                    LetterMaker.MakeLetter(label, text, LetterDefOf.NeutralEvent, targets, null, null, null);
                Find.LetterStack.ReceiveLetter(letter);
            }
        }

    }
    
   
}
