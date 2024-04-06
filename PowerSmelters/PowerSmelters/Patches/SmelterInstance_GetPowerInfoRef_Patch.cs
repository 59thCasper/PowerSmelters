using HarmonyLib;
using static PowerSmelters.PowerSmelters;

namespace PowerSmelters.Patches
{
    [HarmonyPatch(typeof(SmelterInstance))]
    [HarmonyPatch("GetPowerInfoRef")]
    class SmelterInstance_GetPowerInfoRef_Patch
    {

        static void Postfix(SmelterInstance __instance, ref PowerInfo __result)
        {
            bool isMk2 = SaveState.GetResInfoFromId(__instance.commonInfo.resId).displayName.Equals("Smelter MKII");
            if (isMk2)
            {
                
                __instance.powerInfo.UpdateSimplePowerUsage(true);
                __instance._myDef.usesFuel = false;
                __result.usesPowerSystem = true;
                __result.maxPowerConsumption = 1200;
                __result.hasPowerConnection = true;

            }

            bool isMk1 = SaveState.GetResInfoFromId(__instance.commonInfo.resId).displayName.Equals("Smelter");
            if (isMk1)
            {

                __instance.powerInfo.UpdateSimplePowerUsage(true);
                __instance._myDef.usesFuel = false;
                __result.usesPowerSystem = true;
                __result.maxPowerConsumption = 200;
                __result.hasPowerConnection = true;

            }
        }
        

    }
}
