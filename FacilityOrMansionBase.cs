using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using FacilityOrMansion.Patches;

namespace FacilityOrMansion
{
	[BepInPlugin($"{PLUGIN_VERSION}", $"{PLUGIN_NAME}", $"{PLUGIN_VERSION}")]
	public class FacilityOrMansionBase : BaseUnityPlugin
	{
        public const string PLUGIN_GUID = "DeathWrench.FacilityOrMansion";
        public const string PLUGIN_NAME = "Facility or Mansion";
        public const string PLUGIN_VERSION = "1.0.3";
        public static FacilityOrMansionBase Instance { get; private set; }
        public static ConfigEntry<bool> modIsEnabled { get; set; }
        public static ConfigEntry<bool> mansionOnly { get; set; }
        public static ConfigEntry<bool> facilityOnly { get; set; }
        public static ManualLogSource mls { get; private set; }
		private void Awake()
		{
			if (Instance == null)
			{
                Instance = this;
            }
            modIsEnabled = Config.Bind("Facility or Mansion", "Mod Enabled", false, "Enable or disable the mod.");
            mansionOnly = Config.Bind("Choose Only One", "Mansion Only", false, "Interiors set to Mansion.");
            facilityOnly = Config.Bind("Choose Only One", "Facility Only", false, "Interiors set to Facility.");
            mls = BepInEx.Logging.Logger.CreateLogSource(PLUGIN_GUID.ToString());
			mls.LogInfo($"{PLUGIN_NAME} {PLUGIN_VERSION} loaded succesfully!");
			this.harmony.PatchAll(typeof(DungeonFlowTypePatch));
		}
		private readonly Harmony harmony = new Harmony($"{PLUGIN_GUID}");
	}
}
