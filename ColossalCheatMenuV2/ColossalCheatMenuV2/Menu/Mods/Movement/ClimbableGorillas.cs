using BepInEx;
using Colossal.Menu;
using GorillaLocomotion.Climbing;
using Photon.Pun;
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
    public class ClimbableGorillas : MonoBehaviour
    {
        public void Update()
        {
            if (PluginConfig.ClimbableGorillas)
            {
                foreach (VRRig rigs in GorillaParent.instance.vrrigs)
                {
                    if (rigs != GorillaTagger.Instance.offlineVRRig && rigs != null)
                    {
                        if (rigs.transform.GetChild(0).GetChild(5).GetChild(34).GetComponent<GorillaClimbable>() == null)
                            rigs.transform.GetChild(0).GetChild(5).GetChild(34).AddComponent<GorillaClimbable>();
                    }
                }
                //prolly like the worst way to do this but someone else can fix <3
            }
            else
            {
                foreach (VRRig rigs in GorillaParent.instance.vrrigs)
                {
                    if (rigs != GorillaTagger.Instance.offlineVRRig && rigs != null)
                    {
                        if (rigs.transform.GetChild(0).GetChild(5).GetChild(34).GetComponent<GorillaClimbable>() == null)
                            Destroy(rigs.transform.GetChild(0).GetChild(5).GetChild(34).GetComponent<GorillaClimbable>());
                    }
                }

                Destroy(holder.GetComponent<ClimbableGorillas>());
            }
        }
    }
}
