using Colossal;
using Colossal.Menu.ClientHub;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Colossal.Patches
{
    [HarmonyPatch(typeof(VRRig), "OnDisable")]
    internal class DisableRig
    {
        public static bool disablerig = true;
        private static bool Prefix()
        {
            return disablerig;
        }
    }
}