using HarmonyLib;

namespace TestMod
{
    [HarmonyPatch(typeof(PlayerTool))]
    public class PlayerPatch
    {
        [HarmonyPatch(nameof(PlayerTool.Awake))]
        [HarmonyPrefix]
        static void Postfix(PlayerTool __instance)
        {
            if (__instance.GetType()!=typeof(Knife) ||  __instance as Knife == null) return;
            
            var knife = (Knife)__instance;

            float mult = Main.KnifeDistanceMultiplierConfig.Value;

            knife.attackDist *= mult;
        }
    }
}