using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using HarmonyLib;
using Colossal.Patches;
using UnityEngine;

namespace Colossal.Patches
{
    [HarmonyPatch(typeof(GorillaTagger), "Awake")]
    internal class OnGameInit
    {
        public static async void Postfix()
        {
            BepInPatcher.LoadModStuff();
        }
    }
}
