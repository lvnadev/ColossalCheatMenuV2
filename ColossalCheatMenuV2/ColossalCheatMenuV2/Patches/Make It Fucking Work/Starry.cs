using System;
using UnityEngine;
using Valve.VR;

namespace ColossalCheatMenuV2.Patches.MakeItFuckingWork
{
    public class StarrySteamControllerPatch
    {
        public static bool GetLeftJoystickClick()
        {
            if (SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand))
                return true;
            return false;
        }

        public static bool GetRightJoystickClick()
        {
            if(SteamVR_Actions.gorillaTag_RightJoystickClick.GetState(SteamVR_Input_Sources.RightHand))
                return true;
            return false;
        }

        public static bool GetLeftTrigger()
        {
            if(SteamVR_Actions.gorillaTag_LeftTriggerClick.GetState(SteamVR_Input_Sources.LeftHand))
                return true;
            return false;
        }

        public static bool GetRightTrigger()
        {
            if(SteamVR_Actions.gorillaTag_RightTriggerClick.GetState(SteamVR_Input_Sources.RightHand))
                return true;
            return false;
        }
    }
}
