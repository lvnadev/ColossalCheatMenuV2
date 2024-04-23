using System;
using UnityEngine;
using HarmonyLib;
using GorillaNetworking;
using PlayFab;
using System.Collections.Generic;
using UnityEngine.UI;
using BepInEx;

namespace Colossal.Patches
{
    [HarmonyPatch(typeof(GorillaComputer), "GeneralFailureMessage")]
    internal class Heroin : MonoBehaviour
    {
        public static void Postfix(string failMessage)
        {
            if (failMessage.ToLower().Contains("ACCOUNT"))
            {
                Debug.Log("[COLOSSAL] Updating boards for banned account");

                int reasonIndex = failMessage.IndexOf("REASON: ");
                if (reasonIndex != -1)
                {
                    int hoursLeftIndex = failMessage.IndexOf("HOURS LEFT: ");

                    if (hoursLeftIndex != -1)
                    {
                        string hoursLeftSubstring = failMessage.Substring(hoursLeftIndex + "HOURS LEFT: ".Length);
                        if (int.TryParse(hoursLeftSubstring, out int hoursLeft))
                        {
                            string reason = failMessage.Substring(reasonIndex + "REASON: ".Length);

                            if (!failMessage.Contains("INDEFINITELY"))
                            {
                                GorillaComputer.instance.UpdateFailureText("Some mad herion addict moderator has banned you.\n\nTheir shitty fucking reason:\n" + reason);
                                return;
                            }
                            GorillaComputer.instance.UpdateFailureText("Lemming cut off your dick (Bad Ending).\n\nTheir shitty fucking reason:\n" + reason);
                        }
                    }
                }
            }
            else if (failMessage.ToLower().Contains("IP"))
            {
                Debug.Log("[COLOSSAL] Updating boards for banned ip");

                int reasonIndex = failMessage.IndexOf("REASON: ");
                if (reasonIndex != -1)
                {
                    int hoursLeftIndex = failMessage.IndexOf("HOURS LEFT: ");

                    if (hoursLeftIndex != -1)
                    {
                        string hoursLeftSubstring = failMessage.Substring(hoursLeftIndex + "HOURS LEFT: ".Length);
                        if (int.TryParse(hoursLeftSubstring, out int hoursLeft))
                        {
                            string reason = failMessage.Substring(reasonIndex + "REASON: ".Length);

                            if (!failMessage.Contains("INDEFINITELY"))
                            {
                                GorillaComputer.instance.UpdateFailureText("Your PP, I mean IP is to long SHIT BANNED YOUR IP IS BANNED\n\nTheir shitty fucking reason:\n" + reason);
                                return;
                            }
                            GorillaComputer.instance.UpdateFailureText("Lemming cut off your dick (Good Ending).\n\nTheir shitty fucking reason:\n" + reason);
                        }
                    }
                }
            }
            if (GorillaComputer.instance == null)
            {
                GorillaComputer.instance.UpdateFailureText("Something about computer no worky\n\ncall tech support");
            }
        }
    }
}