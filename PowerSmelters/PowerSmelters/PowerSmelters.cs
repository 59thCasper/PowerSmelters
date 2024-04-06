using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Voxeland5.Interface;

namespace PowerSmelters
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class PowerSmelters : BaseUnityPlugin
    {
        private const string MyGUID = "com.casper.PowerSmelters";
        private const string PluginName = "PowerSmelters";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);


        private void Awake()
        {
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();
        }

        private void OnGUI()
        {
            if (SharedState.IsInspectingSmelter && !UIManager.instance.anyMenuOpen && !Player.instance.builder.HasBuilder)
            {
                GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
                {
                    normal = { textColor = Color.white },
                    fontSize = 24
                };

                string powerConsumptionText = $"Current Power Consumption: {SharedState.CurrentPowerConsumption}W";

                GUI.Label(new Rect(20, Screen.height - 100, 560, 50), powerConsumptionText, labelStyle);

            }
        }

        public static class SharedState
        {
            public static bool IsInspectingSmelter { get; set; } = false;
            public static int CurrentPowerConsumption { get; set; } = 0;
        }
    }
}
