using Colossal.Menu;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colossal.Mods
{
    [HarmonyPatch(typeof(VRMapIndex), "MapMyFinger", MethodType.Normal)]
    class FingerIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (PluginConfig.nofinger || FakeQuestMenu.fakeQuestMenuFinger)
            {
                if (ControllerInputPoller.instance.leftControllerGripFloat != 0)
                    ControllerInputPoller.instance.leftControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerGripFloat != 0f)
                    ControllerInputPoller.instance.rightControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.leftControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.rightControllerIndexFloat = 0f;

                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapMiddle), "MapMyFinger", MethodType.Normal)]
    class MiddleIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (PluginConfig.nofinger && FakeQuestMenu.fakeQuestMenuFinger)
            {
                if (ControllerInputPoller.instance.leftControllerGripFloat != 0)
                    ControllerInputPoller.instance.leftControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerGripFloat != 0f)
                    ControllerInputPoller.instance.rightControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.leftControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.rightControllerIndexFloat = 0f;

                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VRMapThumb), "MapMyFinger", MethodType.Normal)]
    class ThumbIndex
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            if (PluginConfig.nofinger || FakeQuestMenu.fakeQuestMenuFinger)
            {
                if(ControllerInputPoller.instance.leftControllerGripFloat != 0)
                    ControllerInputPoller.instance.leftControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerGripFloat != 0f)
                    ControllerInputPoller.instance.rightControllerGripFloat = 0f;
                if (ControllerInputPoller.instance.leftControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
                if (ControllerInputPoller.instance.rightControllerIndexFloat != 0f)
                    ControllerInputPoller.instance.rightControllerIndexFloat = 0f;

                return false;
            }
            return true;
        }
    }
}
