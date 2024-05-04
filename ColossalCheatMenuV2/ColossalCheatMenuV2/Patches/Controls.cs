using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR;
using Valve.VR;

namespace Colossal.Patches
{
    //Starry wrote this so it prob sucks!!!! kisses <3
    //When Adding More ctrl+c ctrl+v
    //In If Statements Do If(SteamVR_Actions.gorillaTag_LeftJoystickClick.GetState(SteamVR_Input_Sources.LeftHand) || Colossal.Patches.OculusLeftJoystick())
    internal class Controls
    {
        public static InputDevice leftControllerOculus;
        public static InputDevice rightControllerOculus;
        public void Update()
        {
            //oculus controllers
            if (!rightControllerOculus.isValid)
                rightControllerOculus = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            
            if (!leftControllerOculus.isValid)
                leftControllerOculus = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }

        public static bool OculusLeftJoystick()
        {
            bool Value = leftControllerOculus.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value);
            return Value;
        }

        public static bool OculusRightJoystick()
        {
            bool Value = rightControllerOculus.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out Value);
            return Value;
        }

        public static bool OculusTrigger()
        {
            bool Value = rightControllerOculus.TryGetFeatureValue(CommonUsages.triggerButton, out Value);
            return Value;
        }
    }
}
