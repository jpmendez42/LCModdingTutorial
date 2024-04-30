using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCModdingTutorial.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCModdingTutorial
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TutorialModBase : BaseUnityPlugin
    {
        private const string modGUID = "LCJJTestmod"; //This needs to be completely unique, even from other mods
        private const string modName = "LC Tutorial Mod";
        private const string modVersion = "1.0.0.0"; //For thunderstore release, only need first 3 digits (e.g. '1.0.0')

        private readonly Harmony harmony = new Harmony(modGUID);
        private static TutorialModBase Instance;

        internal ManualLogSource mls;
        void Awake() //Equivalent of main
        {
            if (Instance == null) //Allows variable referencing in other files for patching
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Mod is activated");

            harmony.PatchAll(typeof(TutorialModBase)); //Leave blank to patch everything
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
