using BepInEx;
using Colossal.Menu;
using Colossal.Patches;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class PlayerScale : MonoBehaviour
    {
        public static float scale = 1f;
        public void Update()
        {
            if (PluginConfig.PlayerScale)
            {
                if (Controls.LeftTrigger() && Controls.RightJoystick())
                {
                    scale -= 0.01f;
                    GorillaLocomotion.Player.Instance.scale = scale;
                }
                if (Controls.RightTrigger() && Controls.RightJoystick())
                {
                    scale += 0.01f;
                    GorillaLocomotion.Player.Instance.scale = scale;
                }
                if (Controls.RightTrigger() && Controls.LeftTrigger() && Controls.RightJoystick())
                {
                    GorillaLocomotion.Player.Instance.scale = 1f;
                    return;
                }

                // stole this from longarms!!!!!!!!
            }
            else
            {
                Destroy(holder.GetComponent<PlayerScale>());
                GorillaLocomotion.Player.Instance.scale = 1f;
            }
        }
    }
}
