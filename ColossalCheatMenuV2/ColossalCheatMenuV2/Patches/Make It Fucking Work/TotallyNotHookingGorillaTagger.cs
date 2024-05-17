
using HarmonyLib;

namespace Colossal.Patches
{
    [HarmonyPatch(typeof(GorillaTagger), "Awake")]
    internal class OnGameInit
    {
        public static async void Postfix() => BepInPatcher.LoadModStuff();
    }
}
