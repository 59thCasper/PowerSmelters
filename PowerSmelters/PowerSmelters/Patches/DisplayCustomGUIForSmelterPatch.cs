using HarmonyLib;
using static PowerSmelters.PowerSmelters;
using UnityEngine;

namespace PowerSmelters.Patches
{
    [HarmonyPatch(typeof(InspectorUI), "SetInspectingMachine")]
    public static class DisplayCustomGUIForSmelterPatch
    {
        static bool Prefix(InspectorUI __instance, ref GenericMachineInstanceRef machineHit)
        {
            bool isInspectingSmelter = machineHit._typeIndex == MachineTypeEnum.Smelter;

            SharedState.IsInspectingSmelter = isInspectingSmelter;

            if (isInspectingSmelter)
            {
                __instance.ClearInspected();

                SharedState.CurrentPowerConsumption = machineHit.CurPowerConsumption;
            }

            return true;
        }
    }

}
