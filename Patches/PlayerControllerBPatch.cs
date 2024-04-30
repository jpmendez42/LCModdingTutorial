using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCModdingTutorial.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix] //(Pre/Post)Fix: Where the code will go, before/after
        static void infiniteSprintPatch(ref float ___sprintMeter) //ref says it refers to something
        {
            ___sprintMeter = 1f;
        }
    }
}
