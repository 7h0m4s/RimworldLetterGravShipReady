using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldLetterGravShipReady
{
    [StaticConstructorOnStartup]
    public class LGSPatcher
    {
        static LGSPatcher()
        {
            Harmony val = new Harmony("7h0m4s.LetterGravShipReady");
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            val.PatchAll(executingAssembly);
        }
    }
}
