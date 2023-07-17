using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Nautilus.Options.Attributes;
using TestMod.Utils;
using ConfigFile = Nautilus.Json.ConfigFile;

namespace TestMod
{
    
    [BepInPlugin(ModId, ModName, Version)]
    public class Main : BaseUnityPlugin
    {
        private const string ModId = "dev.scyye.subnautica.testmod";
        private const string ModName = "Test Mod";
        private const string Version = "1.0.0";
        
        public static Main instance { get; private set; }

        public Logger logger = new Logger(ModName);

        public static ConfigEntry<float> KnifeDistanceMultiplierConfig;
            

        private void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
            if (Math.Abs(KnifeDistanceMultiplierConfig.Value - 1f) < 0.5f)
            {
                Options.KnifeDist = KnifeDistanceMultiplierConfig.Value;
            }
            KnifeDistanceMultiplierConfig.Value = Options.KnifeDist;

            instance = this;
            logger.Log($"v{Version} starting...");
        }

        private void Start()
        {
            KnifeDistanceMultiplierConfig =
                Config.Bind("Test Mod", "Knife Dist Multiplier", 1f, "Knife Distance Multiplier");
        }
    }

    [Menu("Test Mod")]
    public class Options : ConfigFile
    {
        [Slider("  - <color=#cd32cd>Knife Length</color>", Format = "{0:F1}x", DefaultValue = 1f, Min = float.MinValue,
            Max = float.MaxValue, Step = 0.1f, Tooltip = "Re-equip Knife to apply changes")]
        public static float KnifeDist = 1f;
    }
}